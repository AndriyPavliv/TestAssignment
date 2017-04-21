describe('Home view model tests', function () {
    var HomeViewModel = null;
    var firstPageIndex = 1;	
    
    beforeEach(function () {
        //TODO: init model
    });

    afterEach(function () {
        
    });

    it("HomeViewModel exists", function () {
        expect(HomeViewModel).not.toBe(undefined);
        expect(HomeViewModel).not.toBe(null);
    });

    it("HomeViewModel filter exists", function () {
        expect(HomeViewModel.Filter).not.toBe(undefined);
        expect(HomeViewModel.Filter).not.toBe(null);
    });

    it("Can switch to first page", function () {
        //arange
        //act
        HomeViewModel.FirstPage();
        //assert
        expect(HomeViewModel.Filter.PageIdx()).toBe(firstPageIndex);
    });

    it("Can clear filter", function () {
        //arange
        //act
        HomeViewModel.ClearSearch();
        //assert
        expect(HomeViewModel.Filter.Name()).toBe("");        
    });
});