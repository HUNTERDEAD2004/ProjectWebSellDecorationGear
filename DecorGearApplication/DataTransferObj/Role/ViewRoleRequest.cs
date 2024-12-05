using DecorGearApplication.ValueObj.Pagination;

namespace DecorGearApplication.DataTransferObj.Role
{
    public class ViewRoleRequest : PaginationRequest
    {
        public string? SearchName { get; set; }
    }
}
