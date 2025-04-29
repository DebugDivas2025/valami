/*
' Copyright (c) 2025 DebugDivas
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using Hotcakes.Modules.Core.Admin.Configuration;
using System;
using System.Linq;
using System.Web.Mvc;
using valami.valami.Components;
using valami.valami.Models;

namespace valami.valami.Controllers
{
    [DnnHandleError]
    public class OrderController : DnnController
    {
        public ActionResult Index()
        {
            var orders = OrderManager.Instance.GetOrders()
                            .Where(o => o.UserId == User.UserID) // Csak a saját rendeléseit látja
                            .OrderByDescending(o => o.TimeOfOrder);

            var plantingCategories = PlantingCalendarManager.Instance.GetPlantingCalendars();

            //// Passing both orders and categories to the view
            ViewBag.PlantingCategories = plantingCategories;
            return View(orders);
        }
    }
}
