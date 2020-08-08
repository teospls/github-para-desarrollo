

function El_prototipo_y_la_cadena_de_prototipo ()
{
    
// Tipos de datos primitivos
const valorBooleano = false;
const valorNumerico = 10;
const valorTexto = 'Hola mundo!';

//indica que no tiene valor
const valorNulo = null;

//indica que la variable es declarada pero
//aÃºn no tiene un valor asignado
const valorNoDefinido = undefined;

//un valor que no es igual a ningun otro valor
const simbolo = Symbol();

//Todo lo demÃ¡s son objetos:
const elementos = new Array();
const fecha = new Date();

const obj = {
    propiedad1: 12,
    sumar() {
        return this.propiedad1 + 1;
    }
}

console.log('Valor de la funciÃ³n sumar: ', obj.sumar());

valorNumerico.temp = 'abc';

console.log('Valor de la propiedad temp (text):', valorNumerico.temp);

console.log('Pueden dos objetos ser exactamente iguales? ', {} === {});

console.log('Pueden dos primitivas ser exactamente iguales? ', 10 === 10);

}
//El_prototipo_y_la_cadena_de_prototipo();

function El_prototipo_comparado_con_clases__proto__ ()
{

    const Persona = function (nombre) {
        this.nombre = nombre;
    }

    // __proto__
    Persona.prototype.decirNombre = function () {
        console.log("__prot__. Mi nombre es:", this.nombre);
    }

    const persona1 = new Persona("teo");
    persona1.decirNombre();

    const persona2 = new Persona("Lorena");
    persona2.decirNombre();

}
// El_prototipo_comparado_con_clases__proto__();

//Clase para el ejemplo de manejar clase en ves de __proto__
class Persona 
{
    constructor (nombre) 
    {
        this.nombre = nombre;
    }

    decirNombre ()
    {
        console.log("class. Mi nombre es:", this.nombre);
    }
}

function El_prototipo_comparado_con_clases__class()
{
    const persona1 = new Persona("teo");
    persona1.decirNombre();

    const persona2 = new Persona("Lorena");
    persona2.decirNombre();
}
// El_prototipo_comparado_con_clases__class();


//Funciones_Generator
function funcionNormal () 
{
    for (let i = 0; i < 5; i++)
    {
        console.log(i)
        return;        
    }
}
// funcionNormal();

function* generadorSaludo()
{
    yield "Hola!";
    yield "Como estas?";
    yield "Un gusto conocerte";
}

function Usando_funcion_generador ()
{
    let saludo = generadorSaludo();
    console.log(saludo.next().value);
    console.log(saludo.next().value);
    console.log(saludo.next().value);
}

// Usando_funcion_generador();

function* generador_con_iteraciones(iteraciones) 
{
    while (iteraciones>=0)
    {
        yield --iteraciones;
    }
}

function Usando_generador_con_iteraciones()
{
    let iterador = generador_con_iteraciones(4);

    console.log(iterador.next());
    console.log(iterador.next());
    console.log(iterador.next());
    console.log(iterador.next());
    console.log(iterador.next());
    console.log(iterador.next());
}

// Usando_generador_con_iteraciones();


function Desestructuracion_de_objetos()
{
    const arr = [1,2,3,4];
    const temp = [...arr,5,6,7]
    console.log(temp);
}
// Desestructuracion_de_objetos();

function Desestructuracion_de_objetos_example2()
{
    const [all, anno, mes, dia] = /^(\d\d\d\d)-(\d\d)-(\d\d)$/.exec("2020-08-06");
    console.log(all, anno, mes, dia);
}

// Desestructuracion_de_objetos_example2();

function Desestructuracion_de_objetos_con_objetos_Set()
{
    var objetoSet = new Set().add(1).add(2);
    const [x,y] = objetoSet;

    console.log (x,y);
}
// Desestructuracion_de_objetos_con_objetos_Set();

function Desestructuracion_otras_aplicaciones_nombre_completo({nombre: x="Fulano",apellido: y="De tal"} = {})
{
    console.log(x + " " + y);
}

function Usando_Desestructuracion_otras_aplicaciones_nombre_completo()
{
    Desestructuracion_otras_aplicaciones_nombre_completo({});

    Desestructuracion_otras_aplicaciones_nombre_completo({nombre: "Natalia", apellido: "Correa"});

    Desestructuracion_otras_aplicaciones_nombre_completo({nombre: "Natalia"});
}
// Usando_Desestructuracion_otras_aplicaciones_nombre_completo();

function Proxy_in_javascript ()
{
    const target =  function (nombre, apellido) 
    {
        console.log(`mi nombre es ${nombre} ${apellido}`);        
    }

    const handler = {
        apply: function (target, thisValue, args)
        {
            console.log(`Se ha llamado la funcion ${target.name} con los parametros ${args}`);
            return target( ...args);
        }
    }

    const mipProxy = new Proxy(target, handler);
    mipProxy("Natalia", "Correano");

}
// Proxy_in_javascript();


function Observando_propiedades_con_proxies ()
{
    const target = {
        titulo: "Fundación",
        autor: "Issac Asimov",
        genero: "Ciencia Ficcción",
        numeroPaginas: 255
    };

    const handler = {
        get: function (target, prop, proxy) 
        {
            if (prop === "numeroPaginas")
            {
                return `Tengo ${target[prop]} páginas!`;
            }
            else
            {
                return target[prop];
            }
        },
        set (target, prop, value)
        {
            if (prop === "titulo" || prop == "autor")
            {
                console.log(`No puedes modificar la propiedad ${prop}`);                
            }
            else
            {
                target[prop] = value;        
            }
        },
        deleteProperty (target, prop)
        {
            throw Error (`No esta permitido eliminar propiedades de este objeto`);
            return;
        }        
    }

    const miProxy = new Proxy (target, handler);

    //Get
    console.log(miProxy.titulo);
    console.log(miProxy.numeroPaginas);

    //Set
    miProxy.titulo = "Un titulo nuevo";
    miProxy.numeroPaginas = 500
    console.log (miProxy.numeroPaginas);

    //DElete
    // delete miProxy.genero;

    console.log (miProxy);
}
// Observando_propiedades_con_proxies();

function Proxies_revocables ()
{
    const target = {
        titulo: "Fundación",
        autor: "Issac Asimov",
        genero: "Ciencia Ficción",
        numeroPaginas: 344
    };

    const handler = {
        get: function (target, prop, proxy)
        {
            if (prop === "numeroPaginas" )
            {
                return `Tengo ${target[prop]} páginas!`;
            }
            else
            {
                return prop;
            }
        },
        set (target, prop, value)
        {
            if (prop==="titulo" || prop=="autor")
            {
                console.log(`No puedes modificar la propiedad ${prop}`);
            }
            else
            {
                target[prop] = value;
            }
        }
    };

    const {proxy:miProxy, revoke} = Proxy.revocable(target, handler)

    console.log(miProxy.titulo);
    console.log(miProxy.numeroPaginas);

    revoke();

    miProxy.titulo = "Un titulo nuevo!";

}
// Proxies_revocables();

function Casos_de_uso_de_proxies_en_java_script ()
{
    const target = {
        render(val, tag) 
        {
            let htmlTag = document.getElementsByTagName(tag)[0];

            if(!htmlTag)
            {
                htmlTag = document.createElement(tag);
                document.body.appendChild(htmlTag);
            }

            htmlTag.textContent = val;
        }
    };

    const handler = 
    {
        set(target, prop, value)
        {
            target[prop] = value;
            target.render(value, prop == "titulo" ? "h1" : "p");
        }
    };

    const miProxy = new Proxy(target, handler);

    miProxy.titulo = "ABC";
    miProxy.bodyText = "Esta es una prueba de creacion de tag de tipo texto.";
    miProxy.titulo = "ABC-DEFGH";
}
// Casos_de_uso_de_proxies_en_java_script();

function Casos_de_uso_de_proxies_con_tipo_dato_fecha()
{
    let fecha = new Date();

    const miProxyFecha = new Proxy(fecha, 
        {
            get: function (target, prop, proxy)
            {
                if(prop == "format") 
                {
                    return `${target.getDate()}/${target.getMonth()}/${target.getUTCFullYear()}`
                }
                else
                {
                    return target[prop]
                }
            }
        }
        );

        console.log(miProxyFecha.format);
        return;
}
// Casos_de_uso_de_proxies_con_tipo_dato_fecha();

function Promesas_asincronas ()
{
    const promesa = new Promise((resolve, reject) => 
    {
        let allOk = false;

        if(allOk)
        {
            resolve ("Todo salió bien!");
        }
        else
        {
            reject (new Error ("Hubo algún error!"));
        }
    }
    );

    promesa.then(valor=>{
        console.log(valor);
    },
    error => {
        console.log(error);
    });
}
Promesas_asincronas();
