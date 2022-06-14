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
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/",
}).done((result) => {
    console.log(result.results);
    let tmp = "";
    

    $.each(result.results, function (key, val){
        tmp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td
                          <button type="button" onclick="detailpoke('${val.url}')" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#modaldetail">
                              Detail
                         </button>
                    </td>
                </tr>`;
    })
    $("#tablepoke").html(tmp);

    

})




 
function detailpoke(urlPoke) {
    $.ajax({
        url: urlPoke
    }).done((result) => {
        let tmp1 = "";

        function capitalizeFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        }

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
        let hp = `<h6 style = "margin-bottom:4px;" >Hp</h6 ><div  class="progress"> <div class="progress-bar bg-danger" role="progressbar" style="width: ${result.stats[0].base_stat}%"   aria-valuemin="0" aria-valuemax="100">${result.stats[0].base_stat}</div></div> `;
        let att = ` <h6 style = "margin-bottom:4px;" > Attack </h6> <div  class="progress"> <div class="progress-bar " role="progressbar" style="width: ${result.stats[1].base_stat}%"   aria-valuemin="0" aria-valuemax="100">${result.stats[1].base_stat}</div></div> `;
        let def = ` <h6 style = "margin-bottom:4px;" > Defense </h6><div  class="progress"><div class="progress-bar " role="progressbar" style="width: ${result.stats[2].base_stat}%"   aria-valuemin="0" aria-valuemax="100">${result.stats[2].base_stat}</div></div> `;
        let speed = ` <h6 style = "margin-bottom:4px;" > Speed </h6><div  class="progress"> <div class="progress-bar " role="progressbar" style="width: ${result.stats[5].base_stat}%"   aria-valuemin="0" aria-valuemax="100">${result.stats[5].base_stat}</div></div> `;
        $("#data").html(tmp2 + hp + att + def + speed)

        document.getElementById("status").addEventListener("click", myFunction);
        document.getElementById("ability").addEventListener("click", myFunction1);
        function myFunction() {
            $("#data").html(tmp2 + hp + att + def + speed);
        }
        function myFunction1() {
            $("#data").html(ablt);
        }


    })

}