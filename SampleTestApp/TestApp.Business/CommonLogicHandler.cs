using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Interfaces;
using TestApp.Domain.User;

namespace TestApp.Business
{
    public class CommonLogicHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommonLogicHandler> _logger;
        public CommonLogicHandler(ILogger<CommonLogicHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //public IGenericRepository<T> GetGenericRepository<T>()
        //{
        //    var _tp = typeof(T);
        //    switch (_tp.Name.ToLower())
        //    {
        //        case "user":
        //            return _unitOfWork.Users as IGenericRepository<(T)>;
                    
        //    }
        //    return null;
        //}
    }
}
