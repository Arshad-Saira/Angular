import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';  // Import CommonModule if needed
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule


@Component({
  selector: 'app-contact',
  standalone:true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  contact: any = {};

  submitForm(): void {
    console.log('Contact form submitted:', this.contact);
  }
}
