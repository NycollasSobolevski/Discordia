import { Component } from '@angular/core';
import { Jwt } from '../services/person';
import { Router } from '@angular/router';

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
  protected viewConfig = false

  constructor (private router : Router) {}

  ngOnInit() : void {
    if(this.jwt.value == "")
      this.isLogged = false
    else this.isLogged = true
  }



  switchOptions(){
    this.viewConfig = !this.viewConfig
  }

  signOut(){
    sessionStorage.clear()
    localStorage.clear()
    this.router.navigate([""])
    window.location.reload()
  }
}
