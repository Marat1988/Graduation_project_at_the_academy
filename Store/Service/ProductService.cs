using Store.Repository.Products;
using Store.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Store.Service
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

        public List<ProductViewModel> GetAllProducts() => _productRepository.GetAllProducts();
        public List<ProductViewModel> GetChooseProducts(SearchViewModel search) => _productRepository.GetChooseProducts(search);
        public Task Add(ProductViewModel product) => _productRepository.Add(product);
        public Task Update(ProductViewModel product) => _productRepository.Update(product);
        public Task Delete(int Id) => _productRepository.Delete(Id);
        public Task<byte[]> GetPictureProduct(int productId) =>  _productRepository.GetPictureProduct(productId);
        public Task<string> UploadPictureProduct(HttpPostedFileBase uploadImage, int ProductId) => _productRepository.UploadPictureProduct(uploadImage, ProductId);
        public Task DeletePictureFromProduct(int productId) => _productRepository.DeletePictureFromProduct(productId);
    }
}