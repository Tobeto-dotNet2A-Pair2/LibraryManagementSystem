
import { provideRouter } from '@angular/router';
import { routes } from '../../app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { AuthBaseService } from '../../core/services/abstracts/auth-base.service';
import { AuthService } from '../../core/services/concretes/auth.service';
import { authInterceptor } from '../../core/interceptors/auth.interceptor';
import { CachingInterceptors } from "../../core/interceptors/cache/caching.interceptor";
import { ErrorInterceptors } from '../../core/interceptors/error/error.interceptor';
import { LoggingInterceptor } from '../../core/interceptors/logging/log.interceptor';



export function getAppProviders(){
    const authServiceProviders={
        provide:AuthBaseService,
        useClass:AuthService
    };

    return [
        authServiceProviders,
        provideRouter(routes),
        provideHttpClient(withInterceptors([authInterceptor, CachingInterceptors,ErrorInterceptors,LoggingInterceptor]))
    ]
}