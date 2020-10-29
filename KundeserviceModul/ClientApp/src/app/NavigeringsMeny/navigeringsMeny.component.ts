import { Component } from '@angular/core';

@Component({
  selector: 'app-navigeringsMeny',
  templateUrl: './navigeringsMeny.component.html'
})
export class NavigeringsMenyComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}