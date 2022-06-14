// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code
document.getElementById("demonss").addEventListener("click", myFunction);
document.getElementById("demonss").addEventListener("mouseover", myFunction1);



function myFunction() {
    document.getElementById("testing").innerHTML = "Hello,Word!";
}
function myFunction1() {
    document.getElementById("testing").innerHTML = Date();
}





  