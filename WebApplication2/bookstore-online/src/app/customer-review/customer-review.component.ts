import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule


@Component({
  selector: 'app-customer-review',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './customer-review.component.html',
  styleUrl: './customer-review.component.css'
})
export class CustomerReviewComponent {
  // Define the reviews property
  reviews: { name: string; comment: string; }[]= [
    { name: 'Nelson Mandela', comment: 'This book is a grace. I really feel thankful.' },
    { name: 'Jim Collins', comment: 'I feel so thankful and happy to read it. This book is amazing.' },
    { name: 'Adam John', comment: "Amazing!I feel so thankful. Love the writer's perception." }
  ];
}