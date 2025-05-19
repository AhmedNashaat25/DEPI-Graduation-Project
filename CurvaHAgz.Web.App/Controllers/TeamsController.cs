using CurvaHagz.Bussines.App;
using CurvaHagz.Models.App;
using CurvaHAgz.Web.App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurvaHAgz.Web.App.Controllers
{
    public class TeamsController : Controller
    {
        private TeamsManager _TeamsManager { get; set; }
        private UserManager<User> _UserManager { get; set; }
        public TeamsController(TeamsManager teamsManager, UserManager<User> userManager)
        {
            _TeamsManager = teamsManager;
            _UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Team> teams = _TeamsManager.GetAll();
            List<TeamGetAllVm> Model = new List<TeamGetAllVm>();
            foreach (Team team in teams)
            {
                TeamGetAllVm vm = new TeamGetAllVm();
                vm.TeamName = team.TeamName;
                vm.City = team.City;
                vm.CaptainName = team.Captain.FName + " " + team.Captain.LName;
                Model.Add(vm);
            }
            return View(Model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(TeamInfoVm Model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return View("LogIn");
            }

            if (_TeamsManager.IsTeamNameTaken(Model.TeamName))
            {
                ModelState.AddModelError(nameof(CreateTeamVm.TeamName), "This team name is already taken.");
                return RedirectToAction("TeamInfo", Model);
            }
            Team team = new Team();
            team.TeamName = Model.TeamName;
            team.City = Model.City;
            team.CaptainId = user.Id;
            _TeamsManager.Add(team);
            _TeamsManager.AddPlayerToTeam(user, team);
            return RedirectToAction("TeamInfo");
        }
        public async Task<IActionResult> TeamInfo(TeamInfoVm Model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            ViewBag.Owner = user.IsOwner;
            bool memberHasTeam = user.TeamId != null;
            Team team = _TeamsManager.GetInfo(user.TeamId);
            if(team==null)
            {
                return View(Model);
            }
            List<User> members = _TeamsManager.GetMembers(team.TeamId);
            foreach(User member in (List<User>?)members)
            {
                Model.MembersName.Add(member.FName+' '+member.LName);
            }
            Model.CaptainName = Model.MembersName[0];
            Model.Members = _TeamsManager.GetMembers((int)user.TeamId);
            bool isCaptain = false;
            if (team != null) { isCaptain = team.CaptainId == user.Id; }
            ViewBag.MemberHasTeam = memberHasTeam;
            ViewBag.IsCaptain = isCaptain;
            return View(Model);
        }
        public async Task<IActionResult> Join(TeamInfoVm Model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            Team team = _TeamsManager.GetTeamByName(Model.TeamName);
            if (team == null)
            {
                return RedirectToAction("TeamInfo");
            }
            bool IsAdded = _TeamsManager.AddPlayerToTeam(user, team);
            if (!IsAdded)
            {
                return RedirectToAction("TeamInfo");
            }
            return RedirectToAction("TeamInfo");
        }
        public async Task<IActionResult> Removemember(TeamInfoVm Model)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            User user = await _UserManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
             Model.Members = _TeamsManager.GetMembers((int)user.TeamId);
            _TeamsManager.RemoveFromTeam(Model.RemovedMemberId, Model.Members);
            return RedirectToAction("TeamInfo");
        }
    }
}
