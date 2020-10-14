import {Component} from "@angular/core"

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls:["./produto.component.css"]
})

export class ProdutoComponent {

  public nome: string;

  public obtenhaNome(): string {
    return "Samsung";
  }

}
