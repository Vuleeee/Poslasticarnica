import { Narudzbina } from "./Narudzbina.js";
import {Poslasticara} from "./Poslasticara.js"
import { Stolovi } from "./Stolovi.js";

fetch("https://localhost:5001/Poslasticara/PreuzmiPoslasticare").then(p=>
{
    p.json().then(data=>
        {
            data.forEach(poslasticara =>{

                
                let poslasticara1=new Poslasticara(poslasticara.id,poslasticara.naziv,poslasticara.n,poslasticara.m,poslasticara.kapacitet); 
                poslasticara.stolovii.forEach(sto=>
                    {
                        var st = new Stolovi(sto.id,sto.s, sto.pusac, sto.imeRezervacije, sto.kapacitet, sto.maxKapacitet);
                        st.kolekcijaNarudzbina = sto.narudzbinaa;
                        let ukupnaCena = 0;
                        st.kolekcijaNarudzbina.forEach(el => ukupnaCena+=el.cena);
                        st.ukupnaCena = ukupnaCena;
                     
                        poslasticara1.stolovi[sto.s] = st;
                    });
                    
                poslasticara1.crtajPoslasticaru(document.body);
                    
      
                
                    
            });
        });
});





















