import { Component, Input } from '@angular/core';
import { Forum } from '../services/Model';

@Component({
  selector: 'app-menu-component',
  templateUrl: './menu-component.component.html',
  styleUrls: ['./menu-component.component.css']
})
export class MenuComponentComponent {
  @Input() obj : any;

  constructor ( ) { } 

  protected title : string = ""
  protected creator : string = ""

  ngOnInit(){
    this.title = this.obj.title;
    this.creator = this.obj.creator
  }
  
}
