using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.CategoryDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            //MongoClient does using for connecting to the MongoDb
            var client = new MongoClient(databaseSettings.ConnectionString); //we should pass the connection string and its came from the IDatabaseSettings interface
            //GetDatabase method, connects to the defining database.
            var database = client.GetDatabase(databaseSettings.DatabaseName); // this will get the database name from IDatabaseSettings via the client variable which includes connection string
            //GetCollection method, gets the collection from the spesified database. 
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName); //a collection is works like a table
            //This collection will be the Category type and its name will be the name from the databaseSettings.CategoryCollectionName.
            //we gave the connection string to the client variable, then using this variable we gave the database name to the database variable, and then using this database variable we gave the collection name to the instance of IMongoCollection<Category> interface
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var insertingValue = _mapper.Map<Category>(createCategoryDto); //it will get an instance from the CreateCategoryDto and then map it to the Category class.
            //then align the mapped value to the insertingValue variable.
            await _categoryCollection.InsertOneAsync(insertingValue);
            //InsertOneAsync method, inserts a single document to the given collection. 
            //we defined the collection as Category collection at previous, now we can insert a document into this collection.
            //a document is a data in a field.
            //await key word is using for asynchronous processes.
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _categoryCollection.DeleteOneAsync(c => c.CategoryId == categoryId);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var allCategories = await _categoryCollection.Find(c => true).ToListAsync();
            //Find(c=> true) gets all the documents from the collection
            //ToListAsync turn them into a List as asynchronous.
            //then align that list into the values variable
            //our collection's type was Category, so that _categoryCollection variabla has the data as Category type
            //and by that values variable is Category type too.
            return _mapper.Map<List<ResultCategoryDto>>(allCategories);
            //First we map the values variable to ResultCategoryDto type, then return the data as a list with the datas as ResultCategoryDto class
        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(string categoryId)
        {
            var category = await _categoryCollection.Find(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
            // find the spesific data that matches with the exact Id from the categoryCollection.
            //_categoryCollection variable is the Category type.
            //so that it will return a document as Category type.
            return _mapper.Map<ResultCategoryDto>(category);
            //then we are mapping the Category type into the ResultCategoryDto type to return it. 
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var updatingValue = _mapper.Map<Category>(updateCategoryDto);
            //mapping the data from UpdateCategoryDto to Category and aligning it to the updatingValue variable.
            await _categoryCollection.FindOneAndReplaceAsync(c => c.CategoryId == updateCategoryDto.CategoryId, updatingValue);
            //finding the exact data that matches with the updateCategoryDto and then replacing it with the updatingValue.
        }
    }
}
