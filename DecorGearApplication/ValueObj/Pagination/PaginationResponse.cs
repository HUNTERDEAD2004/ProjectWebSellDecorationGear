namespace DecorGearApplication.ValueObj.Pagination
{
    public class PaginationResponse<TDataType>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool HasNext { get; set; }
        public ICollection<TDataType>? Data { get; set; }


        //vi du ap dung
        //public class ProductService
        //{
        //    public PagesRespons<Product> GetPagedProducts(int pageNumber, int pageSize)
        //    {
        //        // Giả sử bạn có phương thức để lấy dữ liệu sản phẩm
        //        var products = GetProductsFromDatabase(pageNumber, pageSize);

        //        // Kiểm tra xem có trang tiếp theo không
        //        bool hasNext = CheckIfHasNextPage(pageNumber, pageSize);

        //        return new PagesRespons<Product>
        //        {
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            HasNext = hasNext,
        //            Data = products
        //        };
        //    }
        //}

    }
}
