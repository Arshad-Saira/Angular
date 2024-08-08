import { Component } from '@angular/core';
import { BookService } from '../book.service';
import { FormsModule } from '@angular/forms';  // Import FormsModule
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule


@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent {
  book: any = {};

  constructor(private bookService: BookService) { }

  addBook(): void {
    this.bookService.addBook(this.book).subscribe(response => {
      console.log('Book added:', response);
    });
  }
}
