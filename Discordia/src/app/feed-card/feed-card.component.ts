import { Component, ViewChild, ViewRef } from '@angular/core';

@Component({
  selector: 'app-feed-card',
  templateUrl: './feed-card.component.html',
  styleUrls: ['./feed-card.component.css']
})
export class FeedCardComponent {
  protected viewConfig = false;
  protected mostConfig(){
    this.viewConfig =  !this.viewConfig;
  }
}
