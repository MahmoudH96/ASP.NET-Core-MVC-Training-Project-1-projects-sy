using EntityFrameworkInDepth.Dtos;
using EntityFrameworkInDepth.Models.Relationships;
using EntityFrameworkInDepth.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkInDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            //Don't forget to create database using update-database 
            //on package manger console, before running the examples
            AddCities();
            AddStoreWithStoreAddres();
            AddProduct();
            UpdateStore();
            RemoveProductsWithProductStores();
        }


        public static void AddCities()
        {
            using (var context = new CommerceDbContext())
            {
                var aleppo = new City()
                {
                    Name = "Aleppo"
                };
                /*
                 * We have three ways to add entity to the database
                 */
                context.Cities.Add(aleppo);
                //context.Add(city);
                //context.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                var damascus = new City()
                {
                    Name = "Damascus"
                };
                var homs = new City()
                {
                    Name = "Homs"
                };
                /*
                 * To add a set of entities we use add range
                 */
                context.AddRange(damascus, homs);
                context.SaveChanges();
            }
        }
        public static void AddStoreWithStoreAddres()
        {
            using (var context = new CommerceDbContext())
            {
                var aleppoCity = context.Cities.Single(city => city.Name == "Aleppo");
                var store = new Store()
                {
                    Name = "My store",
                    OpenHour = new TimeSpan(8, 5, 5),
                    CloseHour = new TimeSpan(18, 5, 5),
                    Note = "My new store",
                    CityId = aleppoCity.Id,
                    StoreAddress = new StoreAddress()
                    {
                        Location = "New aleppo neighbourhood",
                        Landitute = 2.3859,
                        Longitude = 59.65952,
                    }
                };
                context.Stores.Add(store);
                context.SaveChanges();
            }
        }
        public static void AddProduct()
        {
            using (var context = new CommerceDbContext())
            {
                var product = new Product()
                {
                    Name = "Samsung S9",
                    Description = "Great mobile",
                    Price = 700,
                };
                //add product to my store
                var myStore = context.Stores.First();
                product.StoreProducts = new List<StoreProduct>()
                {
                    new StoreProduct()
                    {
                        StoreId=myStore.Id
                        //We did not add the product ID because the list is already inside the product
                    }
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public static void UpdateStore()
        {
            using (var context = new CommerceDbContext())
            {
                int storeId;
                //first method: getting the entity then update it
                var myStore = context.Stores.First();
                storeId = myStore.Id;
                myStore.Name = "My store updated";
                context.Update(myStore);
                //we use context.UpdateRange to update many stores
                context.SaveChanges();
                //second way to update the store based on it Id
                //beside update specific properties only 
                var updateMyStore = new Store()
                {
                    Id = storeId,
                    CloseHour = new TimeSpan(20, 0, 0)
                };
                //update only close hours and keep all other properties only values
                context.Entry(updateMyStore).Property(store => store.CloseHour).IsModified = true;
                context.SaveChanges();

            }
        }
        public static void RemoveProductsWithProductStores()
        {
            using (var context = new CommerceDbContext())
            {
                var productEntity = context.Products
                    .Include(product => product.StoreProducts) //Join to get all product storeProducts
                    .First();
                context.Entry(productEntity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void QueryUsingLinq()
        {
            using (var context = new CommerceDbContext())
            {
                #region Select
                var productsDtoUsingAnonymousTypes = context.Products
                    .Select(product => new
                    {
                        product.Id,
                        product.Name
                    })
                    .ToList();
                var productsDtoUsingDtoClass = context.Products
                    .Select(product => new ProductDto()
                    {
                        Id = product.Id,
                        Name = product.Name
                    })
                    .ToList();
                #endregion

                #region Select many with where

                var cityStores = context.Cities
                    .Where(city => city.Name == "Aleppo")
                    .SelectMany(city => city.Stories)
                    .ToList();

                #endregion

                #region Where 

                var productQuery = "pro".ToUpper();
                var products = context.Products
                    .Where(product =>
                            string.IsNullOrEmpty(productQuery)
                        ||
                            product.Name.ToUpper().Contains(productQuery)
                          ).ToList();

                #endregion

                #region Find

                var storeEntity = context.Stores.Find(1);

                #endregion

                #region Any

                var anyProductInsideAStore = context.StoreProducts.Any(storeProduct => storeProduct.StoreId == 1);

                #endregion

                #region First / FirstOrDefault

                var firstCity = context.Cities.First();

                var firstCityWithA = context.Cities
                    .FirstOrDefault(city => city.Name.Contains('a') || city.Name.Contains('A'));

                #endregion

                #region Count

                var productsWithPriceHigherThan1000 = context.Products.Count(product => product.Price > 1000);
                var allStoresCount = context.Stores.Count();

                #endregion

                #region Sum

                var allProductsPrices = context.Products.Sum(product => product.Price);

                #endregion

                #region Avarage

                var avarageOfProductsPrices = context.Products.Average(product => product.Price);

                #endregion

                #region Max/Min

                var maxProductPrice = context.Products.Max(product => product.Price);

                var minProductPrice = context.Products.Min(product => product.Price);

                #endregion

                #region GroupBy

                var groupProductsByPrice = context.Products
                    .GroupBy(product => product.Price)
                    .ToList();

                #endregion

                #region Order by

                var orderedProducts = context.Products
                    .OrderBy(product => product.Name)
                    .ThenByDescending(product => product.Price)
                    .ToList();

                #endregion

                #region To Dictionary

                var citiesWithStore = context.Cities.Include(city => city.Stories)
                                    .ToDictionary(city => city, city => city.Stories.ToList());

                #endregion
            }
        }
    }
}
