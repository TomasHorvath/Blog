namespace TomasHorvath.BlogEngine.DAL.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<TomasHorvath.BlogEngine.DAL.BlogEngineDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(TomasHorvath.BlogEngine.DAL.BlogEngineDbContext db)
		{
			// clear all data
			db.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
			db.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
			db.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

			var roleStore = new RoleStore<IdentityRole>(db);
			var roleManager = new RoleManager<IdentityRole>(roleStore);
			var userStore = new UserStore<Domain.Author>(db);
			var userManager = new UserManager<Domain.Author>(userStore);

			if (!db.Users.Any())
			{

				var role = roleManager.FindByName("Admin");
				if (role == null)
				{
					role = new IdentityRole("Admin");
					roleManager.Create(role);
				}

				// Create test users
				var user = userManager.FindByName("admin");
				if (user == null)
				{
					var newUser = new Domain.Author()
					{
						UserName = "admin",
						FirstName = "Admin",
						LastName = "User",
						Email = "thsoftware@gmail.com",
						PhoneNumber = "602162083"

					};
					userManager.Create(newUser, "Password1");
					userManager.SetLockoutEnabled(newUser.Id, false);
					userManager.AddToRole(newUser.Id, "Admin");
				}
			}
			var author = userManager.FindByName("admin");
			var blogPost = new Domain.BlogPost()
			{
				Author = author,
				AuthorId = author.Id,
				Content = "Hello world",
				DateOfChange = DateTime.Now,
				DateOfCreated = DateTime.Now,
				DateOfPublished = DateTime.Now,
				Description = "popis",
				Keyword = "SEO keywords",
				Headline = "New blog post",
				Perex = "Short blog post description lorem impsum"
			};

			var blogPost2 = new Domain.BlogPost()
			{
				Author = author,
				AuthorId = author.Id,
				Content = "Hello world1",
				DateOfChange = DateTime.Now,
				DateOfCreated = DateTime.Now,
				DateOfPublished = DateTime.Now,
				Description = "popis",
				Keyword = "SEO keywords",
				Headline = "New blog post1",
				Perex = "Short blog post description lorem impsum 1"
			};

			var blogPost3 = new Domain.BlogPost()
			{
				Author = author,
				AuthorId = author.Id,
				Content = "Hello world",
				DateOfChange = DateTime.Now,
				DateOfCreated = DateTime.Now,
				DateOfPublished = DateTime.Now,
				Description = "popis",
				Keyword = "SEO keywords",
				Headline = "New blog post",
				Perex = "Just test "
			};

			var slug = new Domain.Slug()
			{
				EntityId = blogPost.Id,
				EntityType = Domain.EntityType.BlogPost,
				Url = "hello-world"
			};

			var slug2 = new Domain.Slug()
			{
				EntityId = blogPost2.Id,
				EntityType = Domain.EntityType.BlogPost,
				Url = "blogpost1"
			};

			var slug3 = new Domain.Slug()
			{
				EntityId = blogPost3.Id,
				EntityType = Domain.EntityType.BlogPost,
				Url = "some-url"
			};

			var tag = new Domain.Tag()
			{
				BlogPostId = blogPost.Id,
				TagName = "Test"
			};

			// page 

			var page = new Domain.Page();
			page.Author = author;
			page.AuthorId = author.Id;
			page.Keyword = "kez";
			page.Name = "Contact";
			page.IsContantPage = true;
			page.Headline = "Kontaktni informace";
			page.Description = "Popis";
			page.DisplayOrder = 1;
			page.Content = "obsah";
			page.DateOfChange = DateTime.Now;
			page.DateOfCreated = DateTime.Now;
			page.DateOfPublished = DateTime.Now;

			var kontaktPageUrl = new Domain.Slug();
			kontaktPageUrl.EntityId = page.Id;
			kontaktPageUrl.Url = "kontakt";
			kontaktPageUrl.EntityType = Domain.EntityType.Page;

			var about = new Domain.Page();
			about.Author = author;
			about.AuthorId = author.Id;
			about.Keyword = "kez";
			about.Name = "O nás";
			about.IsContantPage = true;
			about.Headline = "Kontaktni informace";
			about.Description = "Popis";
			about.DisplayOrder = 1;
			about.Content = "obsah";
			about.DateOfChange = DateTime.Now;
			about.DateOfCreated = DateTime.Now;
			about.DateOfPublished = DateTime.Now;

			var aboutPageUrl = new Domain.Slug();
			aboutPageUrl.EntityId = about.Id;
			aboutPageUrl.Url = "o-nas";
			aboutPageUrl.EntityType = Domain.EntityType.Page;

			db.Pages.Add(page);
			db.Pages.Add(about);
			db.Slugs.Add(aboutPageUrl);
			db.Slugs.Add(kontaktPageUrl);

			// settings 

			string type = "";

			var blogName = new Domain.BlogSettings();
			blogName.Key = "BlogName";
			blogName.Value = "Simplycity is key";
			blogName.DataType = type.GetType().ToString();


			var blogMotto = new Domain.BlogSettings();
			blogMotto.Key = "BlogMotto";
			blogMotto.Value = "subheadline motto text";
			blogMotto.DataType = type.GetType().ToString();

			var BrandName = new Domain.BlogSettings();
			BrandName.Key = "BrandName";
			BrandName.Value = "BlogEngine";
			BrandName.DataType = type.GetType().ToString();

			db.Settings.Add(BrandName);
			db.Settings.Add(blogMotto);
			db.Settings.Add(blogName);

			blogPost.Tags.Add(tag);

			db.BlogPosts.Add(blogPost);
			db.BlogPosts.Add(blogPost2);
			db.BlogPosts.Add(blogPost3);
			db.Slugs.Add(slug);
			db.Slugs.Add(slug2);
			db.Slugs.Add(slug3);
		}
	}
}
