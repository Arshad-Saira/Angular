/*import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'bookstore-online';
}*/
import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule
import { BookService } from './book.service';
import { HeaderComponent } from './header/header.component'; // Ensure correct path
import { FooterComponent } from './footer/footer.component'; // Ensure correct path
import { AddBookComponent } from './add-book/add-book.component'; // Ensure correct path
import { AboutComponent } from './about/about.component'; // Ensure correct path
import { BooksComponent } from './books/books.component'; // Ensure correct path
import { ContactComponent } from './contact/contact.component'; // Ensure correct path
import { CustomerReviewComponent } from './customer-review/customer-review.component'; // Ensure correct path

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FooterComponent, 
    HeaderComponent, 
    AddBookComponent,
    AboutComponent,
    BooksComponent,
    ContactComponent,
    CustomerReviewComponent,
    HttpClientModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
//export class AppComponent {
//  title = 'My Online Bookstore';
//}


//
export class AppComponent implements OnInit {
  title = 'My Online Bookstore';
  data: any;

  constructor(private bookService: BookService) {}

  ngOnInit() {
    this.bookService.getBooks().subscribe(response => {
      this.data = response;
    });
  }
}
