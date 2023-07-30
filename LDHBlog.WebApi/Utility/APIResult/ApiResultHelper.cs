using SqlSugar;

namespace LDHBlog.WebApi.Utility.APIResult
{
    public static  class ApiResultHelper
    {
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "操作成功",
                Total = 0

            };
        }
        public static ApiResult Success(dynamic data,RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "操作成功",
                Total = total

            };
        }
        public static ApiResult Error(string msg)
        {
            return new ApiResult { Msg = msg ,Code = 500,Data = null,Total = 0};
        }
    }
}
