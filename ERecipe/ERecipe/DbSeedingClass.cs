using ERecipe.Models;
using ERecipe.Services;
using System.Collections.Generic;

namespace ERecipe
{
    public static class DbSeedingClass
    {
        public static void SeedDataContext(this RecipeDbContext context)
        {
            var recipeAuthors = new List<RecipeAuthor>()
            {
                new RecipeAuthor()
                {
                    Recipe = new Recipe()
                    {
                        Name = "MexicanBurger",
                        Description ="Ready in under 20 minutes, this burger with spiced chipotle chicken breast, in toasted brioche with guacamole, makes for a satisfying weeknight treat for one",
                        Country = new Country()
                        {
                            Name = "America"
                        },
                         Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome recipe", ReviewText = "Mexican burger FTW", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Paul", LastName = "Smith" } },
                            new Review { Headline = "Terrible recipe", ReviewText = "Mexican burger, yuck", Rating = 1,
                             Reviewer = new Reviewer(){ FirstName = "Peter", LastName = "Man" } },
                            new Review { Headline = "Decent recipe", ReviewText = "Mexican burger, mehh...", Rating = 3,
                             Reviewer = new Reviewer(){ FirstName = "Jacob", LastName = "Griffin" } }
                        },
                          RecipeCategories = new List<RecipeCategory>()
                        {
                            new RecipeCategory { Category = new Category() { Name = "burger"}}
                        },
                          RecipeIngredients  = new List<RecipeIngredient>()
                          {
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Chicken breast", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Lime", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Tsp chipotle paste", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Cheese slices", Quantity = 2} },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Bun", Quantity = 1} }
                          },
                          Steps = new List<Step>()
                          {
                              new Step{Description="Put the chicken breast between two pieces of cling film and bash with a rolling pin or pan to about 1cm thick. Mix the chipotle paste with half the lime juice and spread over the chicken."},
                              new Step{Description="Heat a griddle pan over a high heat. Once hot, cook the chicken for 3 mins each side until cooked through, adding the cheese for the final 2 mins of cooking. Add the bun, cut-side down, to the griddle pan to toast lightly. Season the chicken."},
                              new Step{Description="Meanwhile, mash the avocado with the remaining lime juice. Stir in the cherry tomatoes, jalapeño and garlic, and season with a little salt. Spread over the base of the bun, then add the chicken followed by the top of the bun."}
                          }
                    },
                    Author = new Author()
                    {
                         FirstName = "James",
                        LastName = "Potter",
                        Email="james.potter@food.com",
                        PhoneNumber = "1244345"
                    }
                },
                  new RecipeAuthor()
                {
                    Recipe = new Recipe()
                    {
                        Name = "Nacho cheeseburger",
                        Description ="Pile up burgers with cheese, guacamole, chipotle, salsa and nachos for a fiery and zingy twist on a cheeseburger. The nachos give added crunch",
                        Country = new Country()
                        {
                            Name = "Mexic"
                        },
                         Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome recipe", ReviewText = "Nacho burger FTW", Rating = 5,
                             Reviewer = new Reviewer(){ FirstName = "Paul", LastName = "Smith" } },
                            new Review { Headline = "Terrible recipe", ReviewText = "Nacho burger, yuck", Rating = 1,
                             Reviewer = new Reviewer(){ FirstName = "Peter", LastName = "Man" } },
                            new Review { Headline = "Decent recipe", ReviewText = "Nacho burger, mehh...", Rating = 3,
                             Reviewer = new Reviewer(){ FirstName = "Jacob", LastName = "Griffin" } }
                        },
                          RecipeCategories = new List<RecipeCategory>()
                        {
                            new RecipeCategory { Category = new Category() { Name = "burger"}},
                            new RecipeCategory { Category = new Category() { Name = "fast"}}
                        },
                          RecipeIngredients  = new List<RecipeIngredient>()
                          {
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Chicken breast", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Lime", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Tsp chipotle paste", Quantity = 1 } },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Cheese slices", Quantity = 2} },
                             new RecipeIngredient {Ingredient = new Ingredient{Name="Bun", Quantity = 1} }
                          },
                          Steps = new List<Step>()
                          {
                              new Step{Description="Heat the grill to medium-high. Put the burgers on a baking sheet and grill for 5-8 mins on each side until cooked through. For the last minute, top the burgers with the cheese slices and grill until melted. Lightly toast the burger buns. Divide the guacamole, burgers, chipotle or chilli mayo, salsa and nachos, broken up, between each bun. Finish with a sprinkling of torn coriander."}
                          }
                    },
                    Author = new Author()
                    {
                         FirstName = "Pablo",
                        LastName = "Pablito",
                        Email="pablo.pablito@food.com",
                        PhoneNumber = "21245"
                    }
                }
            };

            context.RecipeAuthors.AddRange(recipeAuthors);
            context.SaveChanges();
        }
    }
}