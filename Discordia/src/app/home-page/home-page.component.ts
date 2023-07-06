import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {

  constructor ( private router : Router ) {  }

  session = sessionStorage.getItem("jwt") ?? ""

  ngOnInit(){
    if(this.session != "")
      this.router.navigate(['feed'])
  }


  toLogin(){
    this.router.navigate(['login-page'])
  }
}
