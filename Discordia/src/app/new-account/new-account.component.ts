import { Component, EventEmitter, Output, NgModule } from '@angular/core';
import { UserService } from '../services/person.service';
import { Person } from '../services/person';
import { Router } from '@angular/router';

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
  }

  signInClicked(){
    console.log(this.user + 'OKAY');

    if (!this.checkPassword()) {
      this.alertDiv = true;
      this.alertContent = 'Passwords are different'
      this.alertLevel = 2
      console.log(this.alertLevel);
      
      return
    }

    this.service.registerUser(this.user).subscribe(
      res => console.log(res)
    );
    this.router.navigate(['/login-page'])
  }

  
  loginClicked()
  {
    this.OnLoginClicked.emit();
  }
}
