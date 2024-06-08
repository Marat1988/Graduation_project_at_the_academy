using Store.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Store.Repository.Products
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAllProducts();

        List<ProductViewModel> GetChooseProducts(SearchViewModel search);

        Task Add(ProductViewModel productViewModel);

        Task Update(ProductViewModel productViewModel);

        Task Delete(int Id);

        Task<byte[]> GetPictureProduct(int productId);

        Task<string> UploadPictureProduct(HttpPostedFileBase uploadImage, int ProductId);

        Task DeletePictureFromProduct(int productId);
    }
}
