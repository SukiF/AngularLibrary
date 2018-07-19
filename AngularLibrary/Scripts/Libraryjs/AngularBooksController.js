app.controller("AngularBooksController", function ($scope, $http) {
    $scope.Title = "Books Page";
    $scope.BooksList = [];
    $scope.NewBook = {};
    $scope.GetBooks = function () {
        var url = '/Books/GetBooks';

        $http({ method: 'GET', url: url }).then(function (response) {
            $scope.BooksList = response.data;
        })
    }

    $scope.OpenModal = function (book) {
        $scope.BookToEdit = book;
    }

    $scope.AddBook = function () {
        var url = '/Books/AddBook';

        $http({
            method: 'POST',
            url: url,
            data: $scope.NewBook
        }).then(function (response) {
            $scope.GetBooks();
        })
    }

    $scope.EditBook = function () {
        var settings = {
            method: "POST",
            url: '/Books/EditBook',
            data: $scope.BookToEdit
        }
        $http(settings).then(function (response) {
            if (response == true) {

            }
            else {

            }
            $scope.GetBooks();
        })
    }

    $scope.DeleteBook = function (book) {
        var settings = {
            method: "POST",
            url: '/Books/DeleteBook',
            data: book
        }
        $http(settings).then(function (response) {
            if (response == true) {

            }
            else {

            }
            $scope.GetBooks();
        })
    }
    $scope.GetBooks();
});