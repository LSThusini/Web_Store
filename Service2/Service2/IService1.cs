using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
         char UserLogin(string userEmail, string userPassword);

        [OperationContract]
        bool UserRegister(User newUser);

        [OperationContract]
        List<InvoiceLine> getCarts(int userId);

        [OperationContract]
        bool addProductToCart(int userId, int proId, int quantity);


        [OperationContract]
        bool deleteFromCart(int userId, int proId);

        [OperationContract]
        List<Invoice> getAllInvoices(int userId);

        [OperationContract]
        int getNumItems(int invoiceId);

        [OperationContract]
        decimal getInvoiceTotalPrice(int invoiceId);

        [OperationContract]
        int getUncheackedInvoice(int userId);

        [OperationContract]
        bool checkout(int invoiceId);

        [OperationContract]
        List<InvoiceLine> getProductsOnInvoice(int invoiceId);

        [OperationContract]
        bool updateCart(int invoiceId, int productId, int quantity);

        [OperationContract]
        List<Product> getAllProducts();

        [OperationContract]
        Product GetSingleProduct(int ID);

        [OperationContract]
        User getUser(string Email);

        [OperationContract]
        List<Product> getNewArrivalProducts();

        [OperationContract]
        List<Product> getFeaturedProducts();

        [OperationContract]
        int countProducts();
        [OperationContract]
        int GenerateUserRegReport(DateTime regfordate);

        [OperationContract]
        bool DeleteProductById(int productId);

        [OperationContract]
        bool EditProduct(int productId, string productName, int prodcuctActive, decimal productPrice, string productImage, decimal productDiscount, int CategoryId, string productDescri, int brandId, int productStock);

        [OperationContract]
        bool AddProduct(string productName, int prodcuctActive, decimal productPrice, string productImage, decimal productDiscount, int CategoryId, string productDescri, int brandId, int productStock);

        [OperationContract]
        List<Product> GetProductsByPriceRange(decimal minimumPrice, decimal maximumPrice);
        [OperationContract]
        List<Product> GetProductByBrand(string name);
        [OperationContract]
        List<Product> GetProductByCategory(string name);

        [OperationContract]
        List<InvoiceLineStruct> GetInvoiceLines(int InvoiceId);

        [OperationContract]
        List<Invoice> GetInvoices(int UserId);
    }
}
