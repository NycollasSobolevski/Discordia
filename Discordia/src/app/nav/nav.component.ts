import { Component } from '@angular/core';
import { Jwt } from '../services/person';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  private jwt : Jwt = {
    value : sessionStorage.getItem('jwt') ?? ""
  }
  protected isLogged = false
  ngOnInit() : void {
    if(this.jwt.value == "")
      this.isLogged = false
    else this.isLogged = true
  }
}
