import { Component, Input } from '@angular/core';
import { Forum } from '../services/Model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-component',
  templateUrl: './menu-component.component.html',
  styleUrls: ['./menu-component.component.css']
})
export class MenuComponentComponent {
  @Input() obj : any;

  constructor ( private router : Router ) { } 

  protected title : string = ""
  protected creator : string = ""

  ngOnInit(){
    this.title = this.obj.title;
    this.creator = this.obj.creator
  }

  goToForumPage(){
    this.router.navigate(['forum/'+ this.obj.title])
  }
  
}
