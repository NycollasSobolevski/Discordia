import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css']
})
export class NewAccountComponent {
  @Output() OnLoginClicked = new EventEmitter();

  loginClicked()
  {
    this.OnLoginClicked.emit();
  }
}
