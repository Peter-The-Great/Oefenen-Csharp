
import { persoon } from "./export.js";   
      
function insert() {
   const x = document.createElement("p");
   x.innerHTML = "De persoon is: " + persoon.print();
   document.body.appendChild(x);
}

export default insert;