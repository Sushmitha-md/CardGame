import { Component } from '@angular/core';
import { Cards } from './card.constants';
import { Card } from './Model/card.model';
import { AppService } from './Services/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'my-card-app';
  weather: any;
  cards: Card[] = [];
  selectedCards: Card[] = [];
  sortedCards: Card[] = [];
  constructor(private appservice: AppService) {
    this.cards = Cards;
  }

  getSortedCards() {
    const listOfCards = this.selectedCards.map(id => id.name);
    this.appservice.getSortedCards(listOfCards).subscribe({
      next: (res : any) => {
     if(res.sortedCards.length > 0)
     this.sortedCards = res.sortedCards;
     console.log(this.sortedCards);},
     error: (err: any) => console.log(err)
    })
  }
}
