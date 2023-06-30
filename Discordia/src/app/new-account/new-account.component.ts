import { Component, EventEmitter, Output, NgModule } from '@angular/core';
import { UserService } from '../services/person.service';
import { Person } from '../services/person';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css']
})
export class NewAccountComponent {
  @Output() OnLoginClicked = new EventEmitter();

  router : Router;

  constructor(private service: UserService, router : Router) { 
    this.router = router;
  }

  protected rePassword = '';
  protected alertContent = '';
  protected alertDiv = false;
  protected alertLevel = 1;


  user : Person = {
    id : 0,
    name : '',
    birth : new Date,
    email : '',
    photo : '',
    password : '',
    salt : ''
  }

  checkPassword() {
    console.log(this.user.password === this.rePassword);
    
    return this.user.password === this.rePassword
  }

  validatePassword(newValue : string){
    this.rePassword = newValue
    if(!this.checkPassword())
    {
      this.alertDiv = true;
      this.alertContent = 'Passwords are different'
      this.alertLevel = 1
    }
    else{
      this.alertDiv = false;
    }
  }

  checkData(){
    if(this.user.birth != new Date &&
        this.user.email != '' &&
        this.user.name != '')
          return true;
    return false
  }

  alert( string : string ){
    this.alertDiv = true;
    this.alertContent = string;
    this.alertLevel = 2;
  }


  signInClicked(){
    console.log(this.user + 'OKAY');
    if(!this.checkData()){
      this.alertDiv = true;
      this.alertContent = 'inconsistent data'
      this.alertLevel = 2
      return
    }
    if (!this.checkPassword()) {
      this.alertDiv = true;
      this.alertContent = 'Passwords are different'
      this.alertLevel = 2
      
      return
    }

    this.service.registerUser(this.user)
      .subscribe({
        next: (res) => {
          location.reload()
        },
        error: (error : HttpErrorResponse) => {
          console.log(error.error)
          switch(error.status) {
            case 404:
              console.log("Inconsistencia de dados")
              break
            case 400:
              this.alert(error.error)
              break
            default:
              this.alert('Não foi possivel fazer login no momento')
              break
          }
        },
        complete: () => {

        }
    })
  }

  
  loginClicked()
  {
    this.OnLoginClicked.emit();
  }
}
