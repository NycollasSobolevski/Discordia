import { Component, EventEmitter, Output } from '@angular/core';
import { Person, LoginData } from '../services/person';
import { UserService } from '../services/person.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @Output() onSingInClicked = new EventEmitter();

  constructor(private service: UserService) { }

  user : LoginData = {
    indentify : '',
    password : ''
  }

  signInClicked()
  {
    this.onSingInClicked.emit()
  }


  loginClicked()
  {
    this.service.sendUser(this.user)
  }
}
