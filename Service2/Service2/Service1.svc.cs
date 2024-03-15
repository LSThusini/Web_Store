using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    

    public struct InvoiceLineStruct
    {
        public List<InvoiceLine> ILS_InvoiceLine;
        public List<Product> ILS_Prod;

        public InvoiceLineStruct(List<InvoiceLine> il, List<Product> p)
        {
            ILS_InvoiceLine = il;
            ILS_Prod = p;
        }
    }

    public struct Report
    {
        public string R_Name;
        public int R_ProdOrCatID;
        public double R_Quantity;

        public Report(string name, int prodorcatid, double quantity)
        {
            R_Name = name;
            R_ProdOrCatID = prodorcatid;
            R_Quantity = quantity;
        }
    }

    public class Service1 : IService1
    {

        DataClasses1DataContext data = new DataClasses1DataContext();

        public char UserLogin(string userEmail, string userPassword)
        {

            //Select user with the specified Email
            var userToLog = data.Users.FirstOrDefault(u => u.UserEmail == userEmail);

            if (userToLog == null)
            {
                return 'E'; //Email is not in the database
            }
            else
            {
                //Check if email passwords match
                if (userToLog.UserPass == Secrecy.HashPassword(userPassword))
                {
                    if (userToLog.UserType == "C") //C=Customer
                    {
                        return 'C';
                    }
                    else
                    {
                        return 'A'; //A=Admin
                    }
                }
                else
                {
                    return 'E'; //E=Password does not match
                }

            }

        }

        public User getUser(string Email)
        {
            var newUser = (from u in data.Users where u.UserEmail.Equals(Email) select u).FirstOrDefault();

            if(newUser != null)
            {
                var userToReturn = new User
                {
                    UserId = newUser.UserId,
                    UserEmail = newUser.UserEmail,
                    UserName = newUser.UserName,
                    UserType = newUser.UserType
                };

                return userToReturn;
            }
            else
            {
                return null;
            }
        }

        private List<Invoice> getCheackedInvoices(int userId)
        {
            List<Invoice> invoicesList = new List<Invoice>();
            dynamic newInvoices = (from u in data.Invoices where u.UserId == userId && u.Checked == 1 select u).DefaultIfEmpty();

            if (newInvoices != null)
            {
                foreach (Invoice getInv in newInvoices)
                {
                    var invoiceToReturn = new Invoice
                    {
                        InvoiceId = getInv.InvoiceId,
                        UserId = getInv.UserId,
                        Date = getInv.Date
                    };

                    invoicesList.Add(invoiceToReturn);
                }

                return invoicesList;
            }
            else
            {
                return null;
            }
        }

        public int getUncheackedInvoice(int userId)
        {
            int invoiceId;
            var newInvoice = (from u in data.Invoices where u.UserId == userId && u.Checked == 0 select u).FirstOrDefault();

            if (newInvoice != null)
            {
                invoiceId = newInvoice.InvoiceId;
                return invoiceId;
            }
            else
            {
                return 0;
            }
        }

        public List<InvoiceLine> getCarts(int userId)
        {
            int invoiceId = 0;
            invoiceId = getUncheackedInvoice(userId);
            List<InvoiceLine> list = new List<InvoiceLine>();
            if (invoiceId != 0)
            {
                dynamic newCart = (from u in data.InvoiceLines where u.InvoiceId == invoiceId select u).DefaultIfEmpty();

                if (newCart != null)
                {
                    foreach (InvoiceLine c in newCart)
                    {
                        if (c != null)
                        {
                            var cartToReturn = new InvoiceLine
                            {
                                ProductId = c.ProductId,
                                Quantity = c.Quantity
                            };

                            list.Add(cartToReturn);

                        }
                        else
                        {
                            break;
                        }

                    }
                }
                else
                {
                    return null;
                }

            }


            return list;
        }

        private bool newCart(int invId, int prodId, int quant)
        {
            var cartToAdd = new InvoiceLine
            {
                InvoiceId = invId,
                ProductId = prodId,
                Quantity = quant
            };

            data.InvoiceLines.InsertOnSubmit(cartToAdd);

            try
            {
                data.SubmitChanges();
                Debug.WriteLine("New Cart created");

                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.WriteLine("Failed to create a new cart");
                return false;
            }
        }

        private bool newInvoice(int userId)

        {
            var invoiceToAdd = new Invoice
            {
                UserId = userId,
                Date = DateTime.Now,
                Checked = 0
            };

            Debug.WriteLine("User ID:" + userId);
            Debug.WriteLine("Date:" + invoiceToAdd.Date);


            data.Invoices.InsertOnSubmit(invoiceToAdd);
            try
            {
                data.SubmitChanges();
                Debug.WriteLine("New invoice created:");
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                Debug.WriteLine("Faild to create new invoice");
                return false;
            }
        }

        private int getInvoiceId(int userId)
        {
            var invoiceId = (from u in data.Invoices where u.UserId == userId select u).FirstOrDefault();

            if (invoiceId != null)
            {
                int returnId = invoiceId.InvoiceId;
                Debug.WriteLine("InvoiceId: " + returnId);
                return returnId;

            }
            else
            {
                return 0;
            }
        }

        public bool addProductToCart(int userId, int proId, int quantity)
        {
            Debug.WriteLine("User ID" + userId + " Product ID:" + proId + " Quantiity" + quantity);

            int invoiceId = getUncheackedInvoice(userId);

            if (invoiceId != 0) //There exists an uncheacked product.
            {
                //Add the product on the existing invoice
                var newProInCart = new InvoiceLine
                {
                    InvoiceId = invoiceId,
                    ProductId = proId,
                    Quantity = quantity
                };

                bool isCartAdded = newCart(newProInCart.InvoiceId, newProInCart.ProductId, newProInCart.Quantity);
               
                return isCartAdded;
            }
            else //There is no uncheacked invoice for this user. 
            {
                //create a new invoice and add this product.
                bool isInvoiceCreated = newInvoice(userId);
                if (isInvoiceCreated)
                {
                    int newInvoiceId = getInvoiceId(userId);

                    var newPro = new InvoiceLine
                    {
                        InvoiceId = newInvoiceId,
                        ProductId = proId,
                        Quantity = quantity
                    };
                    bool isAddedOnNewCart = newCart(newPro.InvoiceId, newPro.ProductId, newPro.Quantity);
                    
                    return isAddedOnNewCart;
                }
                else
                {
                    return isInvoiceCreated;
                }

            }
        }

        public bool UserRegister(User newUser)
        {

            //check if the user already exists in the database.
            var userEmails = data.Users.Select(u => u.UserEmail);
            bool userExists = false;
            foreach (var Email in userEmails)
            {
                if (Email.Equals(newUser.UserEmail))
                {
                    userExists = true;
                    return false;
                }
            }

            //If user does not exist in the database store the new user.
            if (userExists == false)
            {
                var NUser = new User
                {
                    UserName = newUser.UserName,
                    UserEmail = newUser.UserEmail,
                    UserPass = Secrecy.HashPassword(newUser.UserPass),
                    UserType = newUser.UserType
                };

                data.Users.InsertOnSubmit(NUser);
                data.SubmitChanges();
                return true;

            }

            return true;
        }

        public bool deleteFromCart(int userId, int proId)
        {
            int invoiceId = getUncheackedInvoice(userId);

            var proOnCart = (from u in data.InvoiceLines
                             where u.InvoiceId == invoiceId && u.ProductId == proId
                             select u).FirstOrDefault();

            data.InvoiceLines.DeleteOnSubmit(proOnCart);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }

        }

        public List<Invoice> getAllInvoices(int userId)
        {
            dynamic userInvoices = getCheackedInvoices(userId);
            List<Invoice> invoicesList = new List<Invoice>();

            if (userInvoices != null)
            {
                foreach (Invoice invoice in userInvoices)
                {
                    var invoiceToReturn = new Invoice
                    {
                        InvoiceId = invoice.InvoiceId,
                        UserId = invoice.UserId,
                        Date = invoice.Date
                    };

                    invoicesList.Add(invoiceToReturn);
                }

                return invoicesList;
            }
            else
            {
                return null;
            }
        }

        public int getNumItems(int invoiceId)
        {
            var newCart = (from u in data.InvoiceLines where u.InvoiceId == invoiceId select u).DefaultIfEmpty();

            if (newCart != null)
            {
                int count = 0;
                foreach (InvoiceLine cart in newCart)
                {
                    count++;
                }

                return count;
            }
            else
            {
                return 0;
            }


        }

        public decimal getInvoiceTotalPrice(int invoiceId)
        {

            dynamic newProds = (from u in data.InvoiceLines where u.InvoiceId == invoiceId select u).DefaultIfEmpty();

            if (newProds != null)
            {
                decimal totalPrice = 0;
                foreach (InvoiceLine cart in newProds)
                {
                    totalPrice += cart.Quantity * getProductPrice(cart.ProductId);
                }

                return totalPrice;

            }
            else
            {
                return 0; //No products for this invoice.
            }
        }

        private decimal getProductPrice(int proId)
        {
            var newPro = (from u in data.Products where u.ProductId == proId select u).FirstOrDefault();

            if (newPro != null)
            {
                decimal price = newPro.ProPrice;
                return price;
            }
            else
            {
                return 0; //No product with the given id.
            }
        }


        public bool checkout(int invoiceId)
        {
            var newInvoice = (from u in data.Invoices where u.InvoiceId == invoiceId select u).FirstOrDefault();

            if (newInvoice != null)
            {
                newInvoice.Checked = 1;

                try
                {
                    data.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Product> getProducts(int Active)
        {
            dynamic product = (from p in data.Products
                               where p.Active.Equals(Active)
                               select p).DefaultIfEmpty();
            var returnItems = new List<Product>();
            if (product != null)
            {
                foreach (Product p in product)
                {
                    var newProductItem = new Product
                    {
                        ProductId = p.ProductId,
                        ProName = p.ProName,
                        ProPrice = p.ProPrice,
                        ProImage = p.ProImage,
                        ProDescr = p.ProDescr,
                        CategoryId = p.CategoryId,
                        Active = p.Active,
                        ProStock = p.ProStock

                    };

                    System.Diagnostics.Debug.WriteLine(p.ProStock);

                    returnItems.Add(newProductItem);
                }
                return returnItems;
            }
            else
            {
                return null;
            }
        }

        public List<InvoiceLine> getProductsOnInvoice(int invoiceId)
        {
            dynamic products = (from u in data.InvoiceLines where u.InvoiceId == invoiceId select u).DefaultIfEmpty();
            List<InvoiceLine> idsList = new List<InvoiceLine>();

            if (products != null)
            {
                foreach (InvoiceLine cart in products)
                {

                    var newCart = new InvoiceLine
                    {
                        ProductId = cart.ProductId,
                        Quantity = cart.Quantity
                    };

                    idsList.Add(newCart);
                }

                return idsList;
            }
            else
            {
                return null;
            }
        }

        public bool updateCart(int invoiceId, int productId, int quantity)
        {
            var getCart = (from u in data.InvoiceLines where  u.InvoiceId == invoiceId && u.ProductId == productId
                           select u).FirstOrDefault();

            if (getCart != null)
            {
                getCart.Quantity = quantity;

                try
                {
                    data.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public List<Product> getAllProducts()
        {
            List<Product> list = new List<Product>();

            dynamic productsList = (from u in data.Products select u).DefaultIfEmpty();

            if(productsList != null){
                
                foreach(Product newPro in productsList)
                {
                    var proToReturn = new Product
                    {
                        ProductId = newPro.ProductId,
                        ProName = newPro.ProName,
                        ProPrice = newPro.ProPrice,
                        ProImage = newPro.ProImage,
                        ProStock = newPro.ProStock
                    };

                    list.Add(proToReturn);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        public int countProducts()
        {
            int counter = 0;

            dynamic productsList = (from u in data.Products select u).DefaultIfEmpty();

            if (productsList != null)
            {

                foreach (Product newPro in productsList)
                {
                    counter++;
                }

                return counter;
            }
            else
            {
                return 0;
            }

        }

        public List<Product> getFeaturedProducts()
        {
            List<Product> list = new List<Product>();

            dynamic productsList = data.Products.Take(8);

            if (productsList != null)
            {

                foreach (Product newPro in productsList)
                {
                    var proToReturn = new Product
                    {
                        ProductId = newPro.ProductId,
                        ProName = newPro.ProName,
                        ProPrice = newPro.ProPrice,
                        ProImage = newPro.ProImage
                    };

                    list.Add(proToReturn);
                }

                return list;
            }
            else
            {
                return null;
            }

        }

        public List<Product> getNewArrivalProducts()
        {
            List<Product> list = new List<Product>();

            dynamic productsList = data.Products.OrderByDescending(p => p.ProductId).Take(8);

            if (productsList != null)
            {

                foreach (Product newPro in productsList)
                {
                    var proToReturn = new Product
                    {
                        ProductId = newPro.ProductId,
                        ProName = newPro.ProName,
                        ProPrice = newPro.ProPrice,
                        ProImage = newPro.ProImage
                    };

                    list.Add(proToReturn);
                }

                return list;
            }
            else
            {
                return null;
            }
        }


        public Product GetSingleProduct(int ID)
        {

            var newPro = (from u in data.Products where u.ProductId == ID select u).FirstOrDefault();

            if (newPro != null)
            {
                var ProToReturn = new Product
                {
                    ProductId = newPro.ProductId,
                    ProName = newPro.ProName,
                    ProPrice = newPro.ProPrice,
                    ProImage = newPro.ProImage,
                    ProDescr = newPro.ProDescr,
                    CategoryId = newPro.CategoryId,
                    BrandId = newPro.BrandId
                };

                return ProToReturn;
            }
            else
            {
                return null; //No Product for the specified Id.
            }
        }

        public int GenerateUserRegReport(DateTime regfordate)
        {
            var users = (from u in data.Users select u);

            if (users != null)
            {
                List<Report> reports = new List<Report>();
                int reg = 0;
                foreach (User u in users)
                {
                    if (u.UserRegDate == regfordate.Date)
                    {
                        reg++;
                    }
                }
                Report r = new Report("Registered Users for " + regfordate.Date, -1, reg);
                reports.Add(r);

                return reg;
            }
            else
            {
                return 0;
            }
        }


        //Function to delete the product by its UNIQUE id from the product management page 
        public bool DeleteProductById(int productId)
        {
            //Search for a product with the specified productId in the data context and take the first one you find 
            var item = (from t in data.Products where t.ProductId == productId select t).FirstOrDefault();
            if (item != null)
            {
                //If the product with the specified productid is found, delete it from the data context
                data.Products.DeleteOnSubmit(item);
                //Submit the changes to the data context to apply the deletion.
                data.SubmitChanges();
                //Return true to indicate a successful deletion.
                return true;
            }
            else
            {
                //if no product with the specified id is found return false to indicate failure
                return false;
            }
        }


        // This method is used to edit a product in a data context based on the given parameters.
        public bool EditProduct(int productId, string productName, int prodcuctActive, decimal productPrice, string productImage, decimal productDiscount, int CategoryId, string productDescri, int brandId, int productStock)
        {
            //check if a product with the specified productId exist in the data context
            var prodExist = (from e in data.Products where (e.ProductId == productId) select e).FirstOrDefault();
            if (prodExist != null)
            {
                //If the product exist update its properties with the provided values
                /*setting up the new product values*/
                prodExist.ProName = productName;
                prodExist.ProImage = productImage;
                prodExist.ProPrice = (decimal)productPrice;
                prodExist.ProDescr = productDescri;
                prodExist.ProStock = productStock;
                //prodExist.Discount = (decimal)productDiscount;
                //submit the changes to the data context.
                data.SubmitChanges();
                //return true to indicate a successful update
                return true;
            }

            else
            {
                //If the product with the specified productId does not exits, return false
                return false;
            }
        }

        //The method to add the product
        public bool AddProduct(string productName, int prodcuctActive, decimal productPrice, string productImage, decimal productDiscount, int CategoryId, string productDescri, int brandId, int productStock)
        {
            //checking if the product already exist in the database
            var existingProduct = (from e in data.Products
                                   where (e.ProImage.Equals(productName) && e.ProPrice.Equals(productPrice))
                                   select e).FirstOrDefault();
            if (existingProduct != null)
            {
                existingProduct.ProName = productName;
                existingProduct.ProImage = productImage;
                existingProduct.ProPrice = productPrice;
                //existingProduct.Category = CategoryId; TODO: Change the variable type
                //existingProduct.Discount = productDiscount;
                existingProduct.ProDescr = productDescri;
                existingProduct.CategoryId = CategoryId;
                existingProduct.BrandId = brandId;
                existingProduct.ProStock = productStock;
                existingProduct.Active = prodcuctActive;
                //send the changes to the database 
                data.SubmitChanges();

                return true;
            }
            else
            {
                //create a new product object and initialize its properties with the provided values
                var addToProduct = new Product
                {

                    ProName = productName,
                    ProImage = productImage,
                    ProPrice = productPrice,
                    //Discount = productDiscount,
                    ProDescr = productDescri,
                    CategoryId = CategoryId,
                    BrandId = brandId,
                    ProStock = productStock,
                    Active = prodcuctActive

                };
                //add the new product to the database. 
                data.Products.InsertOnSubmit(addToProduct);
                try
                {
                    //calling the method to commit the changes and save the new product to the database.
                    data.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
        }

        public bool MakeInvoice(int UserId, List<Product> Products, int IsChecked)
        {
            if ((UserId > 0) && (Products != null))
            {
                Invoice invoice = new Invoice
                {
                    UserId = UserId,
                    Checked = IsChecked
                };

                data.Invoices.InsertOnSubmit(invoice);

                try
                {
                    data.SubmitChanges();
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }

                List<InvoiceLine> iLines = new List<InvoiceLine>();
                foreach (Product p in Products)
                {
                    InvoiceLine iLine = new InvoiceLine
                    {
                        InvoiceId = invoice.InvoiceId,
                        ProductId = p.ProductId,
                        Quantity = p.ProStock,
                    };
                    iLines.Add(iLine);
                }

                data.InvoiceLines.InsertAllOnSubmit(iLines);

                try
                {
                    data.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Invoice> GetInvoices(int UserId)
        {
            var user = (from u in data.Users where u.UserId == UserId select u).FirstOrDefault();
            if (user != null)
            {
                var invs = (from u in data.Invoices where u.UserId.Equals(user.UserId) select u).DefaultIfEmpty();

                if (invs != null)
                {
                    List<Invoice> invoices = new List<Invoice>();
                    foreach (Invoice i in invs)
                    {
                        if (i != null)
                        {
                            Invoice inv = new Invoice
                            {
                                InvoiceId = i.InvoiceId,
                                Checked = i.Checked
                            };
                            invoices.Add(inv);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    return invoices;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public List<InvoiceLineStruct> GetInvoiceLines(int InvoiceId)
        {
            var lines = (from u in data.InvoiceLines where u.InvoiceId.Equals(InvoiceId) select u).DefaultIfEmpty();

            if (lines != null)
            {
                List<InvoiceLine> invoiceLines = new List<InvoiceLine>();
                List<Product> products = new List<Product>();
                foreach (InvoiceLine i in lines)
                {
                    if (i != null)
                    {
                        Product p = new Product
                        {
                            ProName = i.Product.ProName,
                            ProPrice = i.Product.ProPrice
                        };
                        products.Add(p);
                        InvoiceLine l = new InvoiceLine
                        {
                            InvoiceId = i.InvoiceId,
                            ProductId = i.ProductId,
                            Quantity = i.Quantity
                        };
                        invoiceLines.Add(l);
                    }
                    else
                    {
                        return null;
                    }
                }

                List<InvoiceLineStruct> ilines = new List<InvoiceLineStruct>();
                InvoiceLineStruct ILS = new InvoiceLineStruct(invoiceLines, products);
                ilines.Add(ILS);

                return ilines;
            }
            else
            {
                return null;
            }
        }
        public List<Product> GetProductByCategory(string name)
        {
            int catId = getCategogryId(name);
            List<Product> list = new List<Product>();
            //Find the Category ID that is provided and see if it matches 
            dynamic products = (from u in data.Products where u.CategoryId == catId select u).DefaultIfEmpty();
            if (products != null)
            {
                foreach (Product p in products)
                {
                    var newProductItem = new Product
                    {
                        ProductId = p.ProductId,
                        ProName = p.ProName,
                        ProPrice = p.ProPrice,
                        ProImage = p.ProImage,
                        ProDescr = p.ProDescr,
                        CategoryId = p.CategoryId,
                        Active = p.Active,
                        ProStock = p.ProStock,

                    };
                    list.Add(newProductItem);

                }

                // Return the list of matching products.
                return list;
            }
            else
            {
                return null;
            }
        }
        public List<Product> GetProductByBrand(string name)
        {
            int BrandId = getBrandId(name);
            List<Product> list = new List<Product>();
            //Find the Category ID that is provided and see if it matches 
            dynamic products = (from u in data.Products where u.BrandId == BrandId select u).DefaultIfEmpty();
            if (products != null)
            {
                foreach (Product p in products)
                {
                    var newProductItem = new Product
                    {
                        ProductId = p.ProductId,
                        ProName = p.ProName,
                        ProPrice = p.ProPrice,
                        ProImage = p.ProImage,
                        ProDescr = p.ProDescr,
                        CategoryId = p.CategoryId,
                        Active = p.Active,
                        ProStock = p.ProStock

                    };
                    list.Add(newProductItem);

                }

                // Return the list of matching products.
                return list;
            }
            else
            {
                return null;
            }


        }
        //Helper method for getting category name
        private int getCategogryId(string name)
        {
            var cat = (from u in data.Categories where u.CategoryName == name select u).FirstOrDefault();
            if (cat != null)
            {
                return cat.CategoryId;
            }
            else
            {
                return -1;
            }

        }
        //Helper method for getting the Id

        private int getBrandId(string name)
        {
            var brand = (from u in data.Brands where u.BrandName == name select u).FirstOrDefault();
            if (brand != null)
            {
                return brand.BrandId;
            }
            else
            {
                return -1;
            }

        }

        //The method to retrieve product by price ranges
        public List<Product> GetProductsByPriceRange(decimal minimumPrice, decimal maximumPrice)
        {
            var matchingProducts = (from product in data.Products
                                    where (decimal)product.ProPrice > minimumPrice && (decimal)product.ProPrice <= maximumPrice
                                    select product).DefaultIfEmpty();
            var returnItems = new List<Product>();
            // Check if there are matching products.
            if (matchingProducts != null)
            {
                foreach (Product p in matchingProducts)
                {
                    var newProductItem = new Product
                    {
                        ProductId = p.ProductId,
                        ProName = p.ProName,
                        ProPrice = p.ProPrice,
                        ProImage = p.ProImage,
                        ProDescr = p.ProDescr,
                        CategoryId = p.CategoryId,
                        Active = p.Active,
                        ProStock = p.ProStock,

                    };
                    returnItems.Add(newProductItem);

                }

                // Return the list of matching products.
                return returnItems;
            }
            else
            {
                // If no matching products are found, return null to indicate no results.
                return null;
            }
        }

    }



}

