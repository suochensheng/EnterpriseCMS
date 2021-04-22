package com.vfs.china.afccontractservice.config;

import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.web.servlet.FilterRegistrationBean;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;
import org.springframework.web.filter.CorsFilter;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.handler.HandlerInterceptorAdapter;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.Base64;

@Slf4j
@Configuration
public class AppWebConfig implements WebMvcConfigurer{
    @Autowired
    private ApplicationYMLConfig ymlConfig;

    //Enabling CORS for the whole application
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        registry.addMapping("/**");
    }

    @Bean
    public FilterRegistrationBean corsFilter() {
        UrlBasedCorsConfigurationSource source = new UrlBasedCorsConfigurationSource();
        CorsConfiguration config = new CorsConfiguration();
        config.setAllowCredentials(true);
        config.addAllowedOrigin("*");
        config.addAllowedHeader("*");
        config.addAllowedMethod("*");
        source.registerCorsConfiguration("/**", config);
        FilterRegistrationBean bean = new FilterRegistrationBean(new CorsFilter(source));
        bean.setOrder(0);
        return bean;
    }
    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        registry.addInterceptor(new HandlerInterceptorAdapter() {
            @Override
            public boolean preHandle(HttpServletRequest request, HttpServletResponse response, Object handler) throws Exception {
                String authorization = request.getHeader("Authorization");
                //log.info("Authorization:"+authorization);
                if (authorization == null) {
                    log.info("1.Exception:Unauthorized");
                    throw new Exception("Unauthorized");
                }
                else
                {
                    authorization=decodeStr(authorization.replaceAll(" ","").substring(5));
                    if(authorization.equals("")){
                        throw new Exception("Unauthorized");
                    }
                    String auth_user=authorization.split(":")[0];
                    String auth_pwd=authorization.split(":")[1];
                    //log.info("Authorization:"+authorization+" auth_user:"+auth_user+" auth_pwd:"+auth_pwd );
                    if(ymlConfig.getName().equals(auth_user)==false|| ymlConfig.getPwd().equals(auth_pwd)==false){
                        log.info("1.Exception:Unauthorized");
                        throw new Exception("Unauthorized");
                    }
                }

                return super.preHandle(request, response, handler);
            }
        }).addPathPatterns("/**").excludePathPatterns("/contract-callback/**")
                .excludePathPatterns("/swagger-ui/**").excludePathPatterns("/swagger-ui.html")
                .excludePathPatterns("/swagger-resources/**")
                .excludePathPatterns("/configuration/ui")
                .excludePathPatterns("/configuration/security")
                .excludePathPatterns("/v2/api-docs")
                .excludePathPatterns("/error")
                .excludePathPatterns("/webjars/**")
                .excludePathPatterns("/**/favicon.ico");

    }

    private String decodeStr(String encode)
    {
        try {
            byte[] decode = Base64.getDecoder().decode(encode);
            String decodeStr = new String(decode);
            return decodeStr;
        }catch (Exception ex){
            log.error("authorization base64 decode error:"+ex.getMessage());
            return "";
        }
    }
}
