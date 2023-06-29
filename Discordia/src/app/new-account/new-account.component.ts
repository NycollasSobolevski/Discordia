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

    this.service.registerUser(this.user).subscribe(
      res => console.log(res)
    );
    
    location.reload()
  }

  
  loginClicked()
  {
    this.OnLoginClicked.emit();
  }
}
