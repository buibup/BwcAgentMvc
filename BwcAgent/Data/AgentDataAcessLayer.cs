using BwcAgent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwcAgent.Data
{
    public class AgentDataAcessLayer
    {
        AgentDbContext db = new AgentDbContext();

        public IEnumerable<Agent> GetAllAgents()
        {
            try
            {
                return db.Agents.ToList();
            }
            catch
            {
                throw;
            }
        }

        // To filter out the records based on the search string 
        public IEnumerable<Agent> GetSearchResult(string searchString)
        {
            List<Agent> agent = new List<Agent>();
            try
            {
                agent = GetAllAgents().ToList();
                return agent.Where(x => x.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //To Add new agent record       
        public void AddAgent(Agent agent)
        {
            try
            {
                db.Agents.Add(agent);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particular agent  
        public int UpdateAgent(Agent agent)
        {
            try
            {
                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular agent  
        public Agent GetAgentData(int id)
        {
            try
            {
                Agent agent = db.Agents.Find(id);
                return agent;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular agent  
        public void DeleteAgent(int id)
        {
            try
            {
                Agent emp = db.Agents.Find(id);
                db.Agents.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
