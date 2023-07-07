import { Component } from '@angular/core';
import { Jwt, UserData } from '../services/person';
import { Router } from '@angular/router';
import { UserService } from '../services/person.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  private jwt : Jwt = {
    value : sessionStorage.getItem('jwt') ?? ""
  }
  protected user : UserData | any = {
    userName: '',
    email: '',
    photo: '',
    birthday: ''
  }
  protected isLogged = false
  protected viewConfig = false

  constructor (private router : Router, private service : UserService) {}

  ngOnInit() : void {
    if(this.jwt.value == "")
      this.isLogged = false
    else this.isLogged = true
    this.getUserData()
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

  getUserData () {
    this.service.getUserData(this.jwt).subscribe({
      next: (res) => {
        this.user = res
      }
    })    
  }
}
