import { Component, inject } from '@angular/core';
import {FormBuilder, FormControl,FormGroup,ReactiveFormsModule, RequiredValidator, Validators} from '@angular/forms'
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule,MatCardModule,MatButtonModule,MatInputModule,MatFormFieldModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  authService = inject(AuthService)
  private formBuilder = inject(FormBuilder);
  private router = inject(Router); 


  login:FormGroup= this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

  OnSubmit(): void {
    if (this.login.valid) {
      const credentials = this.login.value;
      this.authService.login(credentials).subscribe({
        next: (response) => {
          this.authService.saveUserSession(response); // Guarda sesión
          this.router.navigate(['']);
        },
        error: (error) => {
          console.error('Error de login', error);
        }
      });
    }
  }
}

