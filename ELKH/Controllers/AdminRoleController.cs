using ELKH.Repositories;
using ELKH.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ELKH.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminRoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminRoleController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // ================= LIST =================
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles
                .Select(r => new RoleVM
                {
                    RoleId = r.Id,
                    RoleName = r.Name
                })
                .ToList();

            return View(roles);
        }

        // ================= CREATE =================
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(
                    new IdentityRole(model.RoleName!));

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // ================= EDIT =================
        public async Task<IActionResult> EditRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }
            var model = new RoleVM
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(RoleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                return NotFound();
            }
            role.Name = model.RoleName;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // ================= DELETE =================
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }
            var model = new RoleVM
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(RoleVM model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                return NotFound();
            }
            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);

            if (usersInRole.Any())
            {
                ModelState.AddModelError("", "Cannot delete role. It is assigned to users.");
                return View(model);
            }

            await _roleManager.DeleteAsync(role);

            return RedirectToAction("ListRoles");
        }

        // ================= ASSIGN =================
        public IActionResult AssignRoles()
        {
            var model = new AssignRoleVM
            {
                Roles = _roleManager.Roles
           .Select(r => new RoleVM
           {
               RoleId = r.Id,
               RoleName = r.Name
           })
           .ToList()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoles(AssignRoleVM model)
        {
            ModelState.Remove("Roles");

            // Check if role exists
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                ModelState.AddModelError("", "Role does not exist");
                await ReloadRoles(model);
                return View(model);
            }

            // Find user
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                await ReloadRoles(model);
                return View(model);
            }

            // Assign role
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to assign role");
                await ReloadRoles(model);
                return View(model);
            }

            TempData["Success"] = "Role Assigned Successfully";
            return RedirectToAction("ListRoles");
        }
        private async Task ReloadRoles(AssignRoleVM model)
        {
            model.Roles = _roleManager.Roles
                .Select(r => new RoleVM
                {
                    RoleId = r.Id,
                    RoleName = r.Name
                })
                .ToList();
        }

    }
}

