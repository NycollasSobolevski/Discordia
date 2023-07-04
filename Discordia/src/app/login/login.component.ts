import { Component, EventEmitter, Output } from '@angular/core';
import { LoginData, Jwt } from '../services/person';
import { Person } from '../services/Model'
import { UserService } from '../services/person.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  router: Router;

  @Output() onSingInClicked = new EventEmitter();

  constructor(private service: UserService, router: Router) {
    this.router = router;
  }

  protected alertDiv = false;
  protected alertContent = '';

  user: LoginData = {
    indentify: '',
    password: '',
  };

  signInClicked() {
    this.onSingInClicked.emit();
  }

  invalidUser() {
    this.alertContent = 'Invalid user/password';
    this.alertDiv = true;
  }

    loginClicked() {
		this.service.sendUser(this.user)
			.subscribe({
				next: (res : Jwt) => {
					sessionStorage.setItem('jwt',res.value ?? "")
					this.router.navigate(['/feed'])
				},
				error: (error : HttpErrorResponse) => {
					console.log(error)
					switch(error.status) {
						case 404:
							console.log("Não encontrado")
					}
				},
				complete: () => {

				}
			})
	}
}
