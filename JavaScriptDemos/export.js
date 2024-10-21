const persoon = {
   naam : "Tony",
   beroep: "docent",
   leeftijd: 57,
   print: function() {
      return this.naam + " " + this.beroep + " leeftijd: "+ this.leeftijd
   }
}

export { persoon };
