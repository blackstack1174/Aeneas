using Aeneas.DataController.WebDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Aeneas.WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductDataController : ControllerBase
    {
        private static List<ProductData> _productDatas = new List<ProductData>();

        [HttpPost("Add")]
        public ActionResult Add([FromBody] ProductData productData)
        {
            
            _productDatas.Add(productData);
            return Ok("ok");
        }

        [HttpGet("Remove/{ProductID}")]
        public ActionResult Remove(string ProductID)
        {

            _productDatas.RemoveAll(x => x.ProductID == ProductID);
            return Ok("ok");

        }
        [HttpGet("FindAll")]
        public ActionResult FindAll()
        {
            return Ok(_productDatas);
        }

        [HttpGet("FindByMainCategory/{mainCategory}")]
        public ActionResult FindByMainCategory(string mainCategory)
        {
            var productDatas = _productDatas.Where(x => x.MainCategory == mainCategory);
            return Ok(productDatas);
        }

        [HttpGet("GetProductData")]
        public ActionResult GetProductData()
        {
            Type productDataType = typeof(ProductData);
            List<MemberInfo> members = productDataType.GetMembers().ToList();
            List<string> memberName = members.Where(x => x.MemberType == MemberTypes.Property).Select(x => x.Name).ToList();
            return Ok(memberName);
        }
    }
}
