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
using System;
using System.Collections.Generic;
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
            int userId = UserController.Instance.GetCurrentUserInfo().UserID;
            try
            {
                var orders = OrderManager.Instance.GetOrders()
                                .Where(o => o.UserId == userId)
                                .OrderByDescending(o => o.TimeOfOrder)
                                .ToList(); // biztos ami biztos

                var plantingCategories = PlantingCalendarManager.Instance.GetPlantingCalendars()?.ToList();
                System.Diagnostics.Debug.WriteLine("Lekérdezett rekordok száma: " + plantingCategories.Count());

                foreach (var p in plantingCategories)
                {
                    System.Diagnostics.Debug.WriteLine($"ID: {p.Id}, PlantType: {p.PlantType}");
                }

                ViewBag.PlantingCategories = plantingCategories;
                ViewBag.SelectedCategoryId = plantingCategories?.FirstOrDefault()?.Id ?? 0;
                ViewBag.DebugCategoryId = plantingCategories != null && plantingCategories.Any()
                ? plantingCategories.First().Id.ToString()
                : "nincs";

                System.Diagnostics.Debug.WriteLine("PlantingCategories rekordok: " + plantingCategories.Count);
                return View(orders);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Hiba történt az Index() betöltésekor: " + ex.Message;
                return View(new List<Order>()); // visszatérünk üres listával, hogy legalább ne dobjon el
            }
            
        }

    }
}
