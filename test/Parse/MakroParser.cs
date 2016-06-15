using System.Collections.Generic;
using test.Helper;
using test.Entity;
using System;

namespace test.Parse
{
    public class MakroParser
    {
        private MakroHtmlParser makroParser = new MakroHtmlParser();

        public List<Urunler> insertKirmiziEtUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=21";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 12;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }

        public List<Urunler> insertMeyveUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=10";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 12;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }

        public void insertMarket(Marketler market)
        {
            makroParser.insertMarket(market);
        }

        public List<Urunler> insertSebzeUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=11";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 12;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }

        public List<Urunler> insertSütUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=12";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 13;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }


        public List<Urunler> insertYogurtUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=13";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 13;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }

        public List<Urunler> insertPeynirUrunu(int marketID,int kategoriID)
        {
            string url = "http://online.macrocenter.com.tr/macro/shopProductListing.do?shopId=1&shopCategoryId=77";
            string patern1 = "//div[@class='product_title']";
            string patern2 = "//div[@class='product_price']";
            int aciklamaID = 1025;
            int birimID = 13;
            return makroParser.InsertNewProduct(url, patern1, patern2, aciklamaID, birimID, kategoriID, marketID);
        }
    }
}