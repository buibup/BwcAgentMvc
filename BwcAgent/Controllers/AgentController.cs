using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BwcAgent.Data;
using BwcAgent.Models;
using Microsoft.AspNetCore.Mvc;

namespace BwcAgent.Controllers
{
    public class AgentController : Controller
    {
        AgentDataAcessLayer obj = new AgentDataAcessLayer();
        public IActionResult Index(string searchString)
        {
            List<Agent> lstAgent = new List<Agent>();
            lstAgent = obj.GetAllAgents().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstAgent = obj.GetSearchResult(searchString).ToList();
            }
            return View(lstAgent);
        }

        public ActionResult AddEditAgent(int agentId)
        {
            Agent model = new Agent();
            if (agentId > 0)
            {
                model = obj.GetAgentData(agentId);
            }
            return PartialView("_agentForm", model);
        }

        [HttpPost]
        public ActionResult Create(Agent newAgent)
        {
            if (ModelState.IsValid)
            {
                if (newAgent.Id > 0)
                {
                    obj.UpdateAgent(newAgent);
                }
                else
                {
                    obj.AddAgent(newAgent);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            obj.DeleteAgent(id);
            return RedirectToAction("Index");
        }

        public ActionResult AgentSummary(DateTime dateForm, DateTime dateTo)
        {
            return PartialView("_agentReport");
        }

    }
}