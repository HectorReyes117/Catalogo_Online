$(document).ready(function () {
    $("#formCategories").validate({
        rules: {
            categoryName: {
                required: true
            },
            categoryDescription: {
                required: true
            }      
        },
        messages: {
            categoryName: {
                required: "The category name field is required"
            },
            categoryDescription: {
                required: "The category description field is required"
            }
        }
    });
});


$(document).ready(function () {
    $("#formProduct").validate({
        rules: {          
            productName: {
                required: true
            },
            productPrice: {
                required: true,
                number:true
            }
        },
        messages: {
           productName: {
                required: "The Product Name field is requered"
            },
            productPrice: {
                required: "The Product Price field is requered",
                number:"The Product Price is numeric"
            }
        }
    });
});


$(document).ready(function () {
    $("#formUsers").validate({
        rules: {
            email: {
                required: true,
                email:true
            },
            _password: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            email: {
                required: "The fild is requered"
            },
            _password: {
                required: "The fild is requered"
            }
        }
    });
});

