
export class Narudzbina
{
    constructor(id,vrsta,cena,kolicina)

    {
        this.id=id;
        this.vrsta=vrsta;
        this.cena=cena;
        this.kolicina=kolicina;
        this.miniKontejnerNarudzbina = null;
    }


    crtajNarudzbinu(host)
    {
       
        this.miniKontejnerNarudzbina = document.createElement("div");
        this.miniKontejnerNarudzbina.className = "miniKontNarudzbina";
        host.appendChild(this.miniKontejnerNarudzbina);

      
    }


}