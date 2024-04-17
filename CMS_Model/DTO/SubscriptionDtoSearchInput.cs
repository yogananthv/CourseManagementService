
using System.Runtime.InteropServices;

namespace CMS_Model.DTO
{
    public class SubscriptionDtoSearchInput
    {

        public int PageSize { get; set; } = 100;

        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; } = 1;

        public string Email { get; set; } = "";

        public string Gender { get; set; } = "";

        public string UserName { get; set; } = "";

        public string TrainingName { get; set; } = "";

        public string TrainingCode { get; set; } = "";

        public string Month { get; set; } = "";

        public string CourseName { get; set; } = "";

        public string CourseCode { get; set; } = "";

    }
}
