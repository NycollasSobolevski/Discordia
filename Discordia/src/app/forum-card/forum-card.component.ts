import { Component, Input } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { ForumToBack } from '../services/Forum';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forum-card',
  templateUrl: './forum-card.component.html',
  styleUrls: ['./forum-card.component.css']
})
export class ForumCardComponent {
  @Input() obj : any;

  constructor ( private service : ForumService, private router : Router ) {  }

  private sla : ForumToBack = {
    CreatorIdJwt: '',
    Title: '',
    Description: ''
  }

  ngOnInit(){
    console.log(this.obj);
    
    this.sla.Title = this.obj.title
  }



  func(){
    this.router.navigate(['forum/'+ this.sla.Title])
  }

}
