// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code
console.log("test masuk");

//array 1 dimensi
/*let array = [1, 2, 3, 'qwerty'];
console.log(array);*/


//insert terkahir
/*array.push("last");
console.log(array);
*/

//delete array terakhir
/*array.pop("last");
console.log(array);*/


//insert array first
/*array.unshift("first")
console.log(array);*/

//array multidimensi
//let multi = ['a', 'b', 'c', [1, 2, 3], true];
//console.log(multi);
//buat akses 2
//console.log(multi[3][1]);


//deklarasi object
/*let mhs = {
    nama: "Reinhard",
    nim: "1242323",
    jurunsan: "IT",
    Umur: 80,
    hobby: ["Music", "Game","Wibu"],
    IsActive: true
}

console.log(mhs);
console.log(mhs.hobby[2]);

const user = {}

user.Name = "Reinhard"
user.University = "MCC66"
console.log(user)


user.Name = "Umbu"
console.log(user['Name'])
console.log(user)


const csv = "1|2|3"

const [one, two, three] = csv.split("|")
*/


//array of object
/*const animals = [
    { name:"Nemo", species:"Fish", class: {name:"Invertebrata"} },
    { name: "Terra", species:"Cat", class: { name:"Mamalia"} },
    { name: "Calor", species:"Cat",class: {name:"Mamalia"} }
]

console.log(animals);


const OnlyCats = animals.filter(OnlyCat => OnlyCat.species === "Cat");

let OnlyCats = []
*/
/*for (var i = 0; i < animal.length; i++) {
    if (animal[i].species === "Cat") {
        OnlyCat.push(animal[i]);
    } else {
        animal[i].class.name = "Non-Invertebrata";
    }
}*/

/*animals.forEach(function (animal) {

    if (animal.species === "Cat") {
        OnlyCats.push(animal);
    } else {
        animal.class.name = "Non-Invertebrata";
    }
})

console.log(OnlyCats);
console.log(animals);

OnlyCats.forEach(function (cat) {
    console.log(cat);
})

animals.forEach(function (animal) {
    console.log(animal);
})
*/

/*$("h1").html("testingg jqeury");*/

/// letter
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

//Pokemon
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/",
}).done((result) => {
    console.log(result.results);
    let tmp = "";
    

    $.each(result.results, function (key, val){
        tmp += `<tr>
                    <td>${key + 1}</td>
                    <td>${capitalizeFirstLetter( val.name)}</td >
                    <td>
                        <a onclick="detailpoke('${val.url}')" class="btn btn-primary " data-toggle="modal" data-target="#modaldetail">
                              Detail
                        </a>
                    </td>
                </tr>`;
    })
    $("#tablepoke").html(tmp);
})





function detailpoke(urlPoke) {
    $.ajax({
        url: urlPoke
    }).done((result) =>
    {
        let tmp1 = "";


        $.each(result.types, function (val) {

            if (result.types[val].type.name == "grass") {

                tmp1 += `<span style="margin:5px;" class="badge badge-success">${capitalizeFirstLetter( result.types[val].type.name)
            }</span >`;
            }
            else if (result.types[val].type.name == "poison") {

                tmp1 += `<span style="margin:5px;" class="badge badge-danger">${capitalizeFirstLetter(result.types[val].type.name)}</span>`;

            } else if (result.types[val].type.name == "water") {

                tmp1 += `<span style="margin:5px;" class="badge badge-primary">${capitalizeFirstLetter(result.types[val].type.name)}</span>`;

            } else if (result.types[val].type.name == "fire") {

                tmp1 += `<span style="margin:5px;" class="badge badge-warning">${capitalizeFirstLetter(result.types[val].type.name)}</span>`;

            }else if (result.types[val].type.name == "bug" || "flying") {

                tmp1 += `<span style="margin:5px;" class="badge badge-info">${capitalizeFirstLetter(result.types[val].type.name)}</span>`;

            } else {

                tmp1 += `<span style="margin:5px;" class="badge badge-info">${capitalizeFirstLetter(result.types[val].type.name)}</span>`;
            }
        });

        
        $(".tipe").html(tmp1);
        $("#PokeName").html(capitalizeFirstLetter(result.name));
        $("#image").attr("src", result.sprites.other.home.front_default);
        $("#image1").attr("src", result.sprites.other.dream_world.front_default);
        $("#image2").attr("src", result.sprites.other.home.front_shiny);
        $("#exp").html(result.base_experience);


        //Ability
        let ablt = ""
        $.each(result.abilities, function (val) {
            ablt += `<h3>${capitalizeFirstLetter(result.abilities[val].ability.name)}</h3 >`
        })

        //Status
        let tmp2 = `<h6 style = "margin-bottom:4px;" >Exp</h6> <div  class="progress"> <div class="progress-bar bg-warning" role="progressbar" style="width: ${(result.base_experience / 300) * 100}%"   aria-valuemin="0" aria-valuemax="100">${result.base_experience}/300</div></div> `;
        let hp = `<h6 style = "margin-bottom:4px;" >Hp</h6 ><div  class="progress"> <div class="progress-bar bg-danger" role="progressbar" style="width: ${result.stats[0].base_stat}%"   aria-valuemin="0" aria-valuemax="100" id="Chp">${result.stats[0].base_stat}</div></div> `;
        let att = ` <h6 style = "margin-bottom:4px;" > Attack </h6> <div  class="progress"> <div class="progress-bar " role="progressbar" style="width: ${result.stats[1].base_stat}%"   aria-valuemin="0" aria-valuemax="100" id="Catt">${result.stats[1].base_stat}</div></div> `;
        let def = ` <h6 style = "margin-bottom:4px;" > Defense </h6><div  class="progress"><div class="progress-bar " role="progressbar" style="width: ${result.stats[2].base_stat}%"   aria-valuemin="0" aria-valuemax="100" id="Cdef">${result.stats[2].base_stat}</div></div> `;
        let speed = ` <h6 style = "margin-bottom:4px;" > Speed </h6><div  class="progress"> <div class="progress-bar " role="progressbar" style="width: ${result.stats[5].base_stat}%"   aria-valuemin="0" aria-valuemax="100" id="Cspeed">${result.stats[5].base_stat}</div></div> `;
        $("#data").html(tmp2 + hp + att + def + speed)

        document.getElementById("status").addEventListener("click", myFunction);
        document.getElementById("ability").addEventListener("click", myFunction1);
     /*   document.getElementById("comparison").addEventListener("click", myFunction2);*/


        function myFunction() {
            $("#data").html(tmp2 + hp + att + def + speed);
        }
        function myFunction1() {
            $("#data").html(ablt);
        }

        /*var elementHp = document.getElementById("Chp");
        elementHp.setAttribute("data-value",  result.stats[0].base_stat);

        var elementAtt = document.getElementById("Catt");
        elementAtt.setAttribute("data-value", result.stats[1].base_stat);


        var elementdef = document.getElementById("Cdef");
        elementdef.setAttribute("data-value",  result.stats[2].base_stat);

        var elementspeed = document.getElementById("Cspeed");
        elementspeed.setAttribute("data-value", result.stats[5].base_stat);*/

       
        var myradar = document.getElementById("radarChart").getContext('2d');

        var myRadarChart = new Chart(myradar, {
            type: 'radar',
            data: {
                labels: ["HP", "Attack", "Defense", "Speed"],
                datasets: [{
                    label: "My First dataset",
                    data: [result.stats[0].base_stat,
                        result.stats[1].base_stat,
                        result.stats[2].base_stat,
                        result.stats[5].base_stat
                    ],
                    fill: true,
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    borderColor: 'rgb(255, 99, 132)',
                    pointBackgroundColor: 'rgb(255, 99, 132)',
                    pointBorderColor: '#fff',
                    pointHoverBackgroundColor: '#fff',
                    pointHoverBorderColor: 'rgb(255, 99, 132)'
                }]
            },
            options: {
                responsive: true
            }
        });

      

    })

}


// BAR CHART UNIV
$.ajax({
    url: "https://localhost:44323/API/University",
}).done((result) => {
    let obj = [];
    let UniName = [];
    result.forEach(function (e) {

        console.log(e);
        obj.push(e.id);
        UniName.push(e.name);

    })
    console.log(obj);
    console.log(UniName);
    $.ajax({
        url: "https://localhost:44323/API/Education",
    }).done((res) => {

        console.log(res);

        let jumlah = [];
        let item = [];
        obj.forEach(function (f) {

            item = res.filter(g => g.universityId === f);
            console.log(item);
            jumlah.push(item.length)
        })
        console.log(jumlah);
        console.log(UniName);



        var options = {
            chart: {
                type: 'bar'
            },
            series: [{
                name: 'University',
                data: jumlah
            }],
            xaxis: {
                categories: UniName
            }
        }

        var chart = new ApexCharts(document.querySelector("#chart"), options);

        chart.render();

    })
});







//DONUT BAR GENDER
$.ajax({
    url: "https://localhost:44323/API/Employee/GetAll",
}).done((result) => {
    let emp = "";
    const nik = " ";
    let CM = 0;
    let CF = 0;
    console.log(result);
    $.each(result.data, function (key, val) {

        emp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.firstName}</td >
                    <td>${val.phone}</td >
                    <td>${val.email}</td >
                    <td>
                        <a onclick="details('${val.nik}')" class="btn btn-primary " data-toggle="modal" data-target="#modaldetail2">
                              Detail
                        </a>
                    </td>

                
                </tr>`;

        if (val.gender == "Male") {
            CM += 1;
        } else if (val.gender == "Female") {
            CF += 1;
        }

    })
    console.log(CM);
    console.log(CF);
 
    $("#employeess").html(emp);
 /*   var elementVar = document.getElementById("CFemale");
    elementVar.setAttribute("data-value", CF);

    var elementVar1 = document.getElementById("CMale");
    elementVar1.setAttribute("data-value", CM);
    $("#employees").html(emp);
*/


     var options = {
        chart: {
             type: 'donut',
             animations:
             {
                 enabled: true,
                 easing: 'easeinout',
                 speed: 800,
                 animateGradually: {
                     enabled: true,
                     delay: 150
                 }
             },
             dynamicAnimation:
             {
                 enabled: true,
                 speed: 350
             },
             toolbar: {
                 show: true,
                 offsetX: 0,
                 offsetY: 0,
                 tools:
                 {
                     download: true,
                     selection: true,
                     zoom: true,
                     zoomin: true,
                     zoomout: true,
                     pan: true,
                     reset: true | '<img src="/static/icons/reset.png" width="20">',
                     customIcons: []
                 },
                 export:
                 {
                     csv:
                     {
                         filename: undefined,
                         columnDelimiter: ',',
                         headerCategory: 'category',
                         headerValue: 'value',
                         dateFormatter(timestamp) {
                             return new Date(timestamp).toDateString()
                         }

                     }
                 },
                 svg: {
                     filename: undefined,
                 },
                 png: {
                     filename: undefined,
                 },
                  autoSelected: 'zoom'
             },
         },

        series: [CM, CF],
        labels: ['Male', 'Female']
     }

 

    var chart = new ApexCharts(document.querySelector("#myChart"), options);

    chart.render();


    /*var mychart = document.getElementById("myChart").getContext('2d');
    let round_graph = new Chart(mychart, {
        type: 'doughnut',
        data: {
            labels: ['Male', 'Female'],
            datasets: [{
                lable: 'Samples',
                data: [
                    document.getElementById("CMale").getAttribute("data-value"),
                    document.getElementById("CFemale").getAttribute("data-value")
                ],
                backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc'],
                hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
                hoverBorderColor: "rgba(234, 236, 244, 1)",
            }]
        }*/
    /*})*/
    /*$("#CFemale").attr("data-value", CF)
    $("#CMale").attr("data-value", CM);*/


});




//Ambil University
$.ajax({
    url: "https://localhost:44323/API/University",
}).done((reslt) => {
    console.log(reslt);
    let tmpUni = "";
    for (var i = 0; i < reslt.length; i++) {
        tmpUni += ` <option value="${reslt[i].id}">${reslt[i].name}</option>`
    }
    let option = `  <option value="">Select University</option>${tmpUni}`
    console.log(option);
    $(".kampus").html(option);
    $("#Euni").html(tmpUni);
})


//Fungsi details EMP
function details(ab) {
    $.ajax({
        url: "https://localhost:44323/API/Employee/GetAll"
    }).done((res) => {
   /*     var getPhone = `0${ab}`;*/
        /* console.log(getPhone)*/
        console.log(ab);
        let item = res.data.find(item => item.nik === ab);
        console.log(item);
        $("#Efirstname").val(item.firstName);
        $("#Elastname").val( item.lastName);
        $("#Ephone").val( item.phone);
        $("#Enik").val( item.nik);
        $("#Eemail").val( item.email);
        $("#Ephone").val(item.phone);
        $("#Eid").val(item.eduId);
        console.log(item.gender);


        if (item.gender == "Male") {
            $("#Egender").val("Male");
        }

        else if (item.gender == "Female") {
            $("#Egender").val("Female");
        }


        var ultah = moment(item.birthday).format('yyyy-MM-DD');
        console.log(ultah);

        $("#Ebirthday").val(ultah);


        if (item.degree == "D3") {
            $("#Edegree").val("0");
        }else if (item.degree == "D4") {
            $("#Edegree").val("1");
        }else if (item.degree == "S1") {
            $("#Edegree").val("2");
        } else if (item.degree == "S2") {
            $("#Edegree").val("3");
        } else if (item.degree == "S3") {
            $("#Edegree").val("4");
        }


        /*$("#Edegree").val(item.degree)*/


        $.ajax({
            url: "https://localhost:44323/API/University",
        }).done((reslt) => {

            let itemUni = reslt.find(cUni => cUni.name === item.universityName);
            console.log(itemUni.id);

            $("#Euni").val(itemUni.id);
        })

       /* $("#Euni").val(item.eduId);*/
        $("#Egpa").val(item.gpa);
        $("#Esalary").val(`Rp.${item.salary}`);



        console.log(item.nik);


        $.ajax({
            url: "Employee/GetAll",

        }).done((res1) => {
            console.log(res1);
        })


        $.ajax({
            url: "Employee/GetAllRegis",

        }).done((res2) => {
            console.log(res2);
        }).fail((error) => {
            console.log(error);
        })


    })

}


//fungsi Insert EMPLOYEE
/*document.getElementById("empInsert").addEventListener("click", InsertEMP);*/
/*function InsertEMP() {

    let obj = {
        firstName: document.getElementById("IfirstName").value,
        lastName: document.getElementById("IlastName").value,
        phone: document.getElementById("Iphone").value,
        email: document.getElementById("Iemail").value,
        birthday: document.getElementById("Ibirthday").value,
        gender: document.getElementById("Igender").value,
        password: "123456",
        degree: document.getElementById("Idegree").value,
        gpa: document.getElementById("Igpa").value,
        salary: parseInt(document.getElementById("Isalary").value),
        universityId: parseInt(document.getElementById("Suni").value)
    };

    console.log(obj);

    $.ajax({
        url: "https://localhost:44323/API/Employee/Register",
        type: "POST",
        crossDomain: true,
        data: JSON.stringify(obj),
        contentType: 'application/json;charset=utf-8',
    }).done((result) => {
        alert("Insert Berhasil");
        $('.ajaxTable').DataTable().ajax.reload();
    }).fail((error) => {
        alert("Insert Gagal");

    })
}

*/

$("#empInsert").submit(function (e) {
    e.preventDefault();

    let obj = {
        firstName: document.getElementById("IfirstName").value,
        lastName: document.getElementById("IlastName").value,
        phone: document.getElementById("Iphone").value,
        email: document.getElementById("Iemail").value,
        birthday: document.getElementById("Ibirthday").value,
        gender: document.getElementById("Igender").value,
        password: "123456",
        degree: document.getElementById("Idegree").value,
        gpa: document.getElementById("Igpa").value,
        salary: parseInt(document.getElementById("Isalary").value),
        universityId: parseInt(document.getElementById("Suni").value)
    };
    $.ajax({
        url: "Employee/InsertEmployee",
        type: "POST",
      /*  crossDomain: true,*/
        data: obj,
        /*data: JSON.stringify(obj),*/
       /* contentType: 'application/json;charset=utf-8',*/
    }).done((result) => {
        $("#empModal").modal('hide');
        alert("Insert Berhasil");
        $('.ajaxTable').DataTable().ajax.reload();   
    }).fail((error) => {
        console.log(error);
        alert("Insert Gagal");

    })
})



//Login JWT
$("#Pagelogin").submit(function (e) {
    e.preventDefault();

    let obj = {
        email: document.getElementById("exampleInputEmail1").value,
        password: document.getElementById("exampleInputPassword1").value,
    }

    console.log(obj);
    $.ajax({
        url: "Login/Auth",
        type: "POST",
        data: obj,
    }).done((result) => {
        console.log(result.status);

        switch (result.status) {
            case 200:
                Swal.fire({
                    icon: 'success',
                    title: 'Login Succes',
                    showConfirmButton: false,
                    timer: 3000
                })
                window.location.replace("/TestCors")
                break;
            case 400:
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: result.message,
                })
                break;
            default:
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: result.message,
                })
        }
    }).fail((error) => {
        console.log(error);
        alert("Login Gagal");

    })
})



//Fungsi Update EMPOLYEE
$("#UPDEMP").submit(function (e) {
    e.preventDefault();

    

    let genders = "";

    if (document.getElementById("Egender").value == "Male") {

         genders = document.getElementById("Egender").value = 0
    }
    else if(document.getElementById("Egender").value == "Female") {

        genders = document.getElementById("Egender").value = 1
    }


    var dataa = document.getElementById("Esalary").value.substring(3);
    
    let obj = {
        nik: document.getElementById("Enik").value,
        firstName: document.getElementById("Efirstname").value,
        lastName: document.getElementById("Elastname").value,
        phone: document.getElementById("Ephone").value,
        gender: genders,
        salary: parseInt(dataa),
        birthday: document.getElementById("Ebirthday").value,
        email: document.getElementById("Eemail").value
    }
    console.log(obj);


    $.ajax({
        url: "/Employee/Put",
        type: "PUT",
        data : obj,
        /*crossDomain: true,
        data: JSON.stringify(obj),
        contentType: 'application/json;charset=utf-8',*/
    }).done((result) => {
        $("#modaldetail2").modal('hide');
        alert("Update Berhasil");
        $('.ajaxTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(error);
        alert("Update Gagal");

    })

 
})


//Fungsi Update education
$("#UPDEDU").submit(function (e) {
    e.preventDefault();

    //degreee jadi int!!!!
    let obj = {
        id: parseInt(document.getElementById("Eid").value),
        degree: parseInt(document.getElementById("Edegree").value),
        gpa: document.getElementById("Egpa").value,
        universityId: parseInt(document.getElementById("Euni").value)
    }
    console.log(obj)


    $.ajax({
        url: "https://localhost:44323/API/Education",
        type: "PUT",
        crossDomain: true,
        data: JSON.stringify(obj),
        contentType: 'application/json;charset=utf-8',
    }).done((result) => {
        $("#modaldetail2").modal('hide');
        alert("Update Berhasil");
        $('.ajaxTable').DataTable().ajax.reload();
    }).fail((error) => {
        alert("Update Gagal");

    })


})


//fungsi Delete EMPLOYEE
function DeleteEMP(nik) {

    console.log(nik);

    let obj = { NIK: nik }


    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "https://localhost:44323/API/Employee/DeleteAll",
                type: "POST",
                crossDomain: true,
                data: JSON.stringify(obj),
                contentType: 'application/json;charset=utf-8',
                headers: {
                    'Access-Control-Allow-Origin': '*'
                }
            }).done((result) => {
                $('.ajaxTable').DataTable().ajax.reload();
            }).fail((error) => {
                console.log(error);
                alert("Delete Gagal");

            })
            swalWithBootstrapButtons.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
    })

  /*  $.ajax({
        url: "https://localhost:44323/API/Employee/DeleteAll",
        type: "POST",
        crossDomain: true,
        data: JSON.stringify(obj),
        contentType: 'application/json;charset=utf-8',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    }).done((result) => {
        alert("Delete Berhasil");
        $('.ajaxTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(error);
        alert("Delete Gagal");

    })*/
}







//Datatable
$(document).ready(function () {

    //table EMPLOYEE
    let t = $('.ajaxTable').DataTable({
        dom: 'lBfrtip',
        buttons: [
            'copy', 'csv', 'print',
            {
                extend: 'pdf', title: 'Data Master Employee',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                }
            },
            {
                extend: 'excel', title: 'Data Master Employee',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                }
            }
        ],
        initComplete: function () {
            var btns = $('.dt-button');
            btns.addClass('btn btn-primary btn-sm');
            btns.removeClass('dt-button');
        },
        "ajax": {
              "url":  "Employee/GetAllRegis",
           /* "url": "https://localhost:44323/API/Employee/GetAll",*/
            "dataType": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "firstName"
            },
            {
                "data": "phone",
                 render: function (data) {
                     var telp = data;
                     var result = telp.substring(1);
                     return `<span>+62${result}</span>`;
                 }

            },
            {
                "data": "email"
            },
            {
                "data": "nik",
                 render: function (data, type, row, meta) {
                     return `<a onclick="details('${data}')" class="btn btn-primary" data-toggle="modal" data-target="#modaldetail2">
                              <i class="fa fa-edit"></i></a>
                              <a onclick="DeleteEMP('${data}')" class="btn btn-danger" >
                              <i class="fa fa-trash"></i></a>`
                }

            }
        ]

    });
    t.on("order.dt search.dt", () => {
        let i = 1
        t.cells(null, 0, { search: "applied", order: "applied" }).every(function (cell) {
            this.data(i++)
        })
    }).draw()



    //table POKEMon
    $('.myTable').DataTable({
        dom: 'lBfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        initComplete: function () {
            var btns = $('.dt-button');
            btns.addClass('btn btn-primary btn-sm');
            btns.removeClass('dt-button');
        }
    });
   
});





