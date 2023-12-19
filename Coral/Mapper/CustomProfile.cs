using AutoMapper;

namespace Coral.Mapper {
    public class CustomProfile : Profile {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile() {
            CreateMap<Models.Account, Models.AccountVm>();
        }
    }
}
